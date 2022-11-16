using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace SensModify
{
    class ProcessList
    {
        // Blacklist used in OBS
        private string[] executable_name_blacklist = new string[]{
            "startmenuexperiencehost",
            "applicationframehost",
            "peopleexperiencehost",
            "shellexperiencehost",
            "microsoft.notes",
            "systemsettings",
            "textinputhost",
            "searchapp",
            "video.ui",
            "music.ui",
            "searchui",
            "lockapp",
            "cortana",
            "gamebar",
            "tabtip",
            "time",
            "wwahost",
            "yourphone",
            "cmd",
            "windowsinternal.composableshell.experiences.textinput.inputapp"
        };

        public void PopulateProcesses(ComboBox elem)
        {
            Process[] processes = (from process in Process.GetProcesses()
                where process.MainWindowTitle != String.Empty
                && process.ProcessName != Path.GetFileNameWithoutExtension(Application.ExecutablePath)
                && !executable_name_blacklist.Contains(process.ProcessName.ToLower())
                select process).ToArray();

            elem.DataSource = processes;
            elem.ValueMember = "MainWindowTitle";
        }
    }
}
