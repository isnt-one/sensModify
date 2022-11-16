using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace SensModify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct DefaultSettings
        {
            public int width;
            public int height;
            public int frequency;
            public int sensitivity;
        }

        public struct CurrentProfile
        {
            public string profileName;
            public bool loadedSettings;
        }

        public CurrentProfile currentProfile = new CurrentProfile();

        private string profileDirectory = Path.Combine(Application.StartupPath, "profiles");

        DisplaySettings dispHelper;
        MouseSettings mouseHelper;
        ProcessList procHelper;
        DefaultSettings defaults;

        private void SetupDefaults()
        {
            defaults = new DefaultSettings();

            DEVMODE dm = dispHelper.GetDisplaySettings();

            defaults.width = dm.dmPelsWidth;
            defaults.height = dm.dmPelsHeight;
            defaults.frequency = dm.dmDisplayFrequency;

            int sens = 0;
            mouseHelper.GetMouseSensitivity(out sens);
            defaults.sensitivity = sens;

            currentProfile.loadedSettings = false;
            currentProfile.profileName = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += Application_ApplicationExit;

            Directory.CreateDirectory(profileDirectory);

            fileSystemWatcher1.Path = profileDirectory;
            fileSystemWatcher1.Created += FileCreated;
            fileSystemWatcher1.Deleted += FileDeleted;

            // Create file to trigger file system watcher event
            string dummyfile = Path.Combine(profileDirectory, "dummy.json");
            File.Create(dummyfile).Close();
            File.Delete(dummyfile);

            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            label1.Focus();

            procHelper = new ProcessList();
            procHelper.PopulateProcesses(processCombo);

            dispHelper = new DisplaySettings();
            dispHelper.PopulateResolutions(displaySettingsCombo);

            mouseHelper = new MouseSettings();

            int sens = 0;
            mouseHelper.GetMouseSensitivity(out sens);
            sensTrackbar.Value = sens;

            SetupDefaults();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (!currentProfile.loadedSettings) return;

            mouseHelper.SetMouseSensitivity(defaults.sensitivity);
            dispHelper.ChangeResolution(defaults.width, defaults.height, defaults.frequency);
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            if (!Directory.Exists(profileDirectory))
            {
                Directory.CreateDirectory(profileDirectory);
            }

            string[] files = Directory.GetFiles(profileDirectory, "*.json");

            for (int i=0; i<files.Count(); i++)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]);
            }

            profileList.ComboBox.DataSource = files;
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            if (!Directory.Exists(profileDirectory))
            {
                Directory.CreateDirectory(profileDirectory);
            }

            string[] files = Directory.GetFiles(profileDirectory, "*.json");

            for (int i = 0; i < files.Count(); i++)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]);
            }

            profileList.ComboBox.DataSource = files;
        }

        private void ParseResolutionSelection(out int width, out int height, out int refresh)
        {
            string selection = displaySettingsCombo.SelectedItem.ToString();

            if (selection == String.Empty)
            {
                DEVMODE dm = dispHelper.GetDisplaySettings();
                width = dm.dmPelsWidth;
                height = dm.dmPelsHeight;
                refresh = dm.dmDisplayFrequency;
                return;
            }

            string[] chunks = selection.Split(' ');

            width = int.Parse(chunks[0]);
            height = int.Parse(chunks[2]);
            refresh = int.Parse(chunks[4]);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MouseButton_Click(object sender, EventArgs e)
        {
            settingsPanel.Enabled = true;
            settingsPanel.Show();
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            settingsPanel.Enabled = false;
            settingsPanel.Hide();
        }

        private void SensTrackbar_Changed(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(sensTrackbar, sensTrackbar.Value.ToString());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            sensTrackbar.Value = defaults.sensitivity;

            DEVMODE dm = dispHelper.GetDisplaySettings();

            displaySettingsCombo.SelectedIndex = displaySettingsCombo.Items.IndexOf(String.Format("{0} x {1} @ {2}", dm.dmPelsWidth, dm.dmPelsHeight, dm.dmDisplayFrequency));
        }

        private void SelectedProgram(object sender, EventArgs e)
        {
            if (processCombo.SelectedItem.ToString() == String.Empty) return;

            Process process = (Process)processCombo.SelectedItem;
            profileName.Text = process.ProcessName;

            label1.Focus();
        }

        private void displaySelectionChanged(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void programKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            if (processCombo.SelectedItem.ToString() == String.Empty) return;

            Process process = (Process)processCombo.SelectedItem;
            profileName.Text = process.ProcessName;
        }

        private void displayKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void SelectedProfile(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void ResolutionEnabledCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool state = resolutionEnabledCheckbox.Checked;
            displaySettingsCombo.Enabled = state;
        }

        private void MouseEnabledCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            bool state = mouseEnabledCheckbox.Checked;
            sensTrackbar.Enabled = state;
        }

        private void SensTrackbar_Scroll(object sender, EventArgs e)
        {
            label1.Focus();
        }

        public int LimitInclusive(int value, int min, int max)
        {
            return Math.Min(max, Math.Max(value, min));
        }

        private void SaveProfileButton_Click(object sender, EventArgs e)
        {
            if (profileName.Text == ""
                || profileName.Text == "..."
                || profileName.Text == String.Empty)
            {
                MessageBox.Show("Invalid program", "Invalid settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filepath = Path.Combine(profileDirectory, String.Format("{0}.json", profileName.Text));

            int sensitivity = 0;
            int width = 0;
            int height = 0;
            int frequency = 0;

            sensitivity = LimitInclusive(sensTrackbar.Value, 1, 20);

            ParseResolutionSelection(out width, out height, out frequency);

            string settingsData = JsonConvert.SerializeObject(new {
                Program = profileName.Text,
                Mouse = new {
                    Enabled = mouseEnabledCheckbox.Checked,
                    Sensitivity = sensitivity
                },
                Display = new {
                    Enabled = resolutionEnabledCheckbox.Checked,
                    Width = width,
                    Height = height,
                    Frequency = frequency
                }
            }, Formatting.Indented);

            Directory.CreateDirectory(profileDirectory);
            File.WriteAllText(filepath, settingsData);
        }

        List<string> activeProcesses = new List<string>();

        private void LoadSettings(string profile)
        {
            currentProfile.profileName = activeProcesses.First();

            string filename = String.Format("{0}.json", profile);
            string path = Path.Combine(profileDirectory, filename);

            if (!Directory.Exists(profileDirectory))
            {
                Directory.CreateDirectory(profileDirectory);
                return;
            }

            if (!File.Exists(path)) return;

            JsonSettings settings = JsonConvert.DeserializeObject<JsonSettings>(File.ReadAllText(path));

            if (settings.mouse.Enabled)
            {
                int sens = settings.mouse.Sensitivity;
                mouseHelper.SetMouseSensitivity(sens);

                Console.WriteLine(String.Format("Changed mouse sensitivity to {0}", sens));
            }

            if (settings.display.Enabled)
            {
                int width = settings.display.Width;
                int height = settings.display.Height;
                int rate = settings.display.Frequency;

                dispHelper.ChangeResolution(width, height, rate);

                Console.WriteLine(String.Format("Changed resolution to {0} x {1} @ {2}", width, height, rate));
            }

            statusProfile.Text = profile;

            currentProfile.loadedSettings = true;
        }

        private void UnloadSettings()
        {
            currentProfile.profileName = "";

            mouseHelper.SetMouseSensitivity(defaults.sensitivity);
            dispHelper.ChangeResolution(defaults.width, defaults.height, defaults.frequency);

            statusProfile.Text = "none";

            currentProfile.loadedSettings = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (profileList.Items.Count == 0)
                return;

            if (currentProfile.loadedSettings)
            {
                if (!activeProcesses.Contains(currentProfile.profileName))
                {
                    UnloadSettings();
                    return;
                }

                Process[] proc = Process.GetProcessesByName(currentProfile.profileName);
                if (proc.Count() >= 1)
                {
                    return;
                }
            }

            activeProcesses.Clear();

            Process[] plist = Process.GetProcesses();
            string[] processNames = Array.ConvertAll(plist, p => p.ProcessName);

            //ComboBox.ObjectCollection profileCollection = profileList.ComboBox.Items;

            foreach (string profile in profileList.ComboBox.Items)
            {
                Process[] processes = (from p in Process.GetProcesses()
                                       where p.ProcessName == profile
                                       select p).ToArray();

                if (processes.Count() >= 1)
                {
                    activeProcesses.Add(processes[0].ProcessName);
                }
            }

            Console.WriteLine(String.Format("Found {0} active games", activeProcesses.Count()));

            if (!currentProfile.loadedSettings && activeProcesses.Count() >= 1)
            {
                LoadSettings(activeProcesses.First());
            }
        }

        private void DeleteProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (profileList.Items.Count == 0) return;

            if (!Directory.Exists(profileDirectory)) return;

            string filename = String.Format("{0}.json", profileList.SelectedItem.ToString());

            File.Delete(Path.Combine(profileDirectory, filename));
        }

        private void LoadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (profileList.Items.Count == 0) return;

            string filename = String.Format("{0}.json", profileList.SelectedItem.ToString());
            string path = Path.Combine(profileDirectory, filename);

            if (!Directory.Exists(profileDirectory)) return;
            if (!File.Exists(path)) return;

            try
            {
                JsonSettings settings = JsonConvert.DeserializeObject<JsonSettings>(File.ReadAllText(path));

                profileName.Text = settings.Program;

                mouseEnabledCheckbox.Checked = settings.mouse.Enabled;
                sensTrackbar.Value = settings.mouse.Sensitivity;

                resolutionEnabledCheckbox.Checked = settings.display.Enabled;

                string res = String.Format("{0} x {1} @ {2}", settings.display.Width, settings.display.Height, settings.display.Frequency);

                displaySettingsCombo.SelectedIndex = displaySettingsCombo.Items.IndexOf(res);
            }
            catch (Exception)
            {
                MessageBox.Show(String.Format("Could not parse {0}", filename), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                File.Delete(path);
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(0, "Program hidden", "Hiding window to keep your taskbar clean", ToolTipIcon.Info);
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            mouseHelper.SetMouseSensitivity(defaults.sensitivity);
            dispHelper.ChangeResolution(defaults.width, defaults.height, defaults.frequency);
            statusProfile.Text = "none";
        }

        private void reloadProcessListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            procHelper.PopulateProcesses(processCombo);
        }
    }
}
