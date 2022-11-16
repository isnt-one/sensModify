namespace SensModify
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileList = new System.Windows.Forms.ToolStripComboBox();
            this.processCombo = new System.Windows.Forms.ComboBox();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.resolutionEnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.mouseEnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.displaySettingsCombo = new System.Windows.Forms.ComboBox();
            this.profileName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.saveProfileButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sensTrackbar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProfile = new System.Windows.Forms.ToolStripStatusLabel();
            this.reloadProcessListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.profileList});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(350, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadProcessListToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadProfileToolStripMenuItem,
            this.deleteProfileToolStripMenuItem});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.profileToolStripMenuItem.Text = "Profiles";
            // 
            // loadProfileToolStripMenuItem
            // 
            this.loadProfileToolStripMenuItem.Name = "loadProfileToolStripMenuItem";
            this.loadProfileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.loadProfileToolStripMenuItem.Text = "Load profile";
            this.loadProfileToolStripMenuItem.Click += new System.EventHandler(this.LoadProfileToolStripMenuItem_Click);
            // 
            // deleteProfileToolStripMenuItem
            // 
            this.deleteProfileToolStripMenuItem.Name = "deleteProfileToolStripMenuItem";
            this.deleteProfileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteProfileToolStripMenuItem.Text = "Delete profile";
            this.deleteProfileToolStripMenuItem.Click += new System.EventHandler(this.DeleteProfileToolStripMenuItem_Click);
            // 
            // profileList
            // 
            this.profileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileList.Name = "profileList";
            this.profileList.Size = new System.Drawing.Size(121, 23);
            this.profileList.DropDownClosed += new System.EventHandler(this.SelectedProfile);
            this.profileList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.displayKeyPress);
            // 
            // processCombo
            // 
            this.processCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processCombo.FormattingEnabled = true;
            this.processCombo.Location = new System.Drawing.Point(75, 27);
            this.processCombo.Name = "processCombo";
            this.processCombo.Size = new System.Drawing.Size(260, 21);
            this.processCombo.TabIndex = 2;
            this.processCombo.DropDownClosed += new System.EventHandler(this.SelectedProgram);
            this.processCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.programKeyDown);
            this.processCombo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.displayKeyPress);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.button2);
            this.settingsPanel.Controls.Add(this.label9);
            this.settingsPanel.Controls.Add(this.resolutionEnabledCheckbox);
            this.settingsPanel.Controls.Add(this.mouseEnabledCheckbox);
            this.settingsPanel.Controls.Add(this.displaySettingsCombo);
            this.settingsPanel.Controls.Add(this.profileName);
            this.settingsPanel.Controls.Add(this.label7);
            this.settingsPanel.Controls.Add(this.saveProfileButton);
            this.settingsPanel.Controls.Add(this.button1);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.sensTrackbar);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Location = new System.Drawing.Point(12, 61);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(326, 336);
            this.settingsPanel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(320, 53);
            this.button2.TabIndex = 16;
            this.button2.Text = "Revert settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Resolutions:";
            // 
            // resolutionEnabledCheckbox
            // 
            this.resolutionEnabledCheckbox.AutoSize = true;
            this.resolutionEnabledCheckbox.Checked = true;
            this.resolutionEnabledCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.resolutionEnabledCheckbox.Location = new System.Drawing.Point(7, 163);
            this.resolutionEnabledCheckbox.Name = "resolutionEnabledCheckbox";
            this.resolutionEnabledCheckbox.Size = new System.Drawing.Size(117, 17);
            this.resolutionEnabledCheckbox.TabIndex = 3;
            this.resolutionEnabledCheckbox.Text = "Resolution enabled";
            this.resolutionEnabledCheckbox.UseVisualStyleBackColor = true;
            this.resolutionEnabledCheckbox.CheckedChanged += new System.EventHandler(this.ResolutionEnabledCheckbox_CheckedChanged);
            // 
            // mouseEnabledCheckbox
            // 
            this.mouseEnabledCheckbox.AutoSize = true;
            this.mouseEnabledCheckbox.Checked = true;
            this.mouseEnabledCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mouseEnabledCheckbox.Location = new System.Drawing.Point(6, 51);
            this.mouseEnabledCheckbox.Name = "mouseEnabledCheckbox";
            this.mouseEnabledCheckbox.Size = new System.Drawing.Size(114, 17);
            this.mouseEnabledCheckbox.TabIndex = 14;
            this.mouseEnabledCheckbox.Text = "Sensitivity enabled";
            this.mouseEnabledCheckbox.UseVisualStyleBackColor = true;
            this.mouseEnabledCheckbox.CheckedChanged += new System.EventHandler(this.MouseEnabledCheckbox_CheckedChanged);
            // 
            // displaySettingsCombo
            // 
            this.displaySettingsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displaySettingsCombo.FormattingEnabled = true;
            this.displaySettingsCombo.Location = new System.Drawing.Point(78, 187);
            this.displaySettingsCombo.Name = "displaySettingsCombo";
            this.displaySettingsCombo.Size = new System.Drawing.Size(245, 21);
            this.displaySettingsCombo.TabIndex = 13;
            this.displaySettingsCombo.DropDownClosed += new System.EventHandler(this.displaySelectionChanged);
            this.displaySettingsCombo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.displayKeyPress);
            // 
            // profileName
            // 
            this.profileName.AutoSize = true;
            this.profileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.profileName.Location = new System.Drawing.Point(55, 4);
            this.profileName.Name = "profileName";
            this.profileName.Size = new System.Drawing.Size(20, 18);
            this.profileName.TabIndex = 3;
            this.profileName.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "Profile:";
            // 
            // saveProfileButton
            // 
            this.saveProfileButton.Location = new System.Drawing.Point(167, 220);
            this.saveProfileButton.Name = "saveProfileButton";
            this.saveProfileButton.Size = new System.Drawing.Size(156, 53);
            this.saveProfileButton.TabIndex = 12;
            this.saveProfileButton.Text = "Save profile";
            this.saveProfileButton.UseVisualStyleBackColor = true;
            this.saveProfileButton.Click += new System.EventHandler(this.SaveProfileButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 53);
            this.button1.TabIndex = 11;
            this.button1.Text = "Use default settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sensitivity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Display settings";
            // 
            // sensTrackbar
            // 
            this.sensTrackbar.LargeChange = 2;
            this.sensTrackbar.Location = new System.Drawing.Point(3, 90);
            this.sensTrackbar.Maximum = 20;
            this.sensTrackbar.Minimum = 1;
            this.sensTrackbar.Name = "sensTrackbar";
            this.sensTrackbar.Size = new System.Drawing.Size(320, 45);
            this.sensTrackbar.TabIndex = 3;
            this.sensTrackbar.Value = 1;
            this.sensTrackbar.Scroll += new System.EventHandler(this.SensTrackbar_Scroll);
            this.sensTrackbar.ValueChanged += new System.EventHandler(this.SensTrackbar_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mouse settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Programs:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "*.json";
            this.fileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.FileName;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "lol";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.NotifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusProfile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(350, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel1.Text = "Current profile:";
            // 
            // statusProfile
            // 
            this.statusProfile.Name = "statusProfile";
            this.statusProfile.Size = new System.Drawing.Size(34, 17);
            this.statusProfile.Text = "none";
            // 
            // reloadProcessListToolStripMenuItem
            // 
            this.reloadProcessListToolStripMenuItem.Name = "reloadProcessListToolStripMenuItem";
            this.reloadProcessListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reloadProcessListToolStripMenuItem.Text = "Reload process list";
            this.reloadProcessListToolStripMenuItem.Click += new System.EventHandler(this.reloadProcessListToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 420);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.processCombo);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouse & Display Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ComboBox processCombo;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar sensTrackbar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label profileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button saveProfileButton;
        private System.Windows.Forms.ComboBox displaySettingsCombo;
        private System.Windows.Forms.ToolStripMenuItem deleteProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox profileList;
        private System.Windows.Forms.ToolStripMenuItem loadProfileToolStripMenuItem;
        private System.Windows.Forms.CheckBox resolutionEnabledCheckbox;
        private System.Windows.Forms.CheckBox mouseEnabledCheckbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusProfile;
        private System.Windows.Forms.ToolStripMenuItem reloadProcessListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

