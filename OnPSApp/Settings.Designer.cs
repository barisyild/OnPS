namespace OnPS
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PsnPlatformComboBox = new System.Windows.Forms.ComboBox();
            this.PsnLogoutButton = new System.Windows.Forms.Button();
            this.PsnUsernameLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SteamUsernameLabel = new System.Windows.Forms.Label();
            this.SteamLogButton = new System.Windows.Forms.Button();
            this.GameType = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PsnPlatformComboBox);
            this.groupBox1.Controls.Add(this.PsnLogoutButton);
            this.groupBox1.Controls.Add(this.PsnUsernameLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PlayStation Network";
            // 
            // PsnPlatformComboBox
            // 
            this.PsnPlatformComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PsnPlatformComboBox.FormattingEnabled = true;
            this.PsnPlatformComboBox.Items.AddRange(new object[] {
            "PS4",
            "PSVITA",
            "PS3"});
            this.PsnPlatformComboBox.Location = new System.Drawing.Point(30, 19);
            this.PsnPlatformComboBox.Name = "PsnPlatformComboBox";
            this.PsnPlatformComboBox.Size = new System.Drawing.Size(227, 21);
            this.PsnPlatformComboBox.TabIndex = 7;
            this.PsnPlatformComboBox.SelectedIndexChanged += new System.EventHandler(this.PsnPlatformComboBox_SelectedIndexChanged);
            // 
            // PsnLogoutButton
            // 
            this.PsnLogoutButton.Location = new System.Drawing.Point(106, 59);
            this.PsnLogoutButton.Name = "PsnLogoutButton";
            this.PsnLogoutButton.Size = new System.Drawing.Size(75, 26);
            this.PsnLogoutButton.TabIndex = 1;
            this.PsnLogoutButton.Text = "Logout";
            this.PsnLogoutButton.UseVisualStyleBackColor = true;
            this.PsnLogoutButton.Click += new System.EventHandler(this.PsnLogoutButton_Click);
            // 
            // PsnUsernameLabel
            // 
            this.PsnUsernameLabel.Location = new System.Drawing.Point(0, 43);
            this.PsnUsernameLabel.Name = "PsnUsernameLabel";
            this.PsnUsernameLabel.Size = new System.Drawing.Size(287, 13);
            this.PsnUsernameLabel.TabIndex = 0;
            this.PsnUsernameLabel.Text = "username";
            this.PsnUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SteamUsernameLabel);
            this.groupBox2.Controls.Add(this.SteamLogButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Steam";
            // 
            // SteamUsernameLabel
            // 
            this.SteamUsernameLabel.Location = new System.Drawing.Point(0, 20);
            this.SteamUsernameLabel.Name = "SteamUsernameLabel";
            this.SteamUsernameLabel.Size = new System.Drawing.Size(287, 13);
            this.SteamUsernameLabel.TabIndex = 4;
            this.SteamUsernameLabel.Text = "username";
            this.SteamUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SteamLogButton
            // 
            this.SteamLogButton.Location = new System.Drawing.Point(106, 36);
            this.SteamLogButton.Name = "SteamLogButton";
            this.SteamLogButton.Size = new System.Drawing.Size(75, 26);
            this.SteamLogButton.TabIndex = 3;
            this.SteamLogButton.Text = "Login";
            this.SteamLogButton.UseVisualStyleBackColor = true;
            this.SteamLogButton.Click += new System.EventHandler(this.SteamLogoutButton_Click);
            // 
            // GameType
            // 
            this.GameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameType.FormattingEnabled = true;
            this.GameType.Location = new System.Drawing.Point(45, 195);
            this.GameType.Name = "GameType";
            this.GameType.Size = new System.Drawing.Size(227, 21);
            this.GameType.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 222);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Start at startup";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 253);
            this.Controls.Add(this.GameType);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button PsnLogoutButton;
        private System.Windows.Forms.Label PsnUsernameLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SteamLogButton;
        private System.Windows.Forms.ComboBox PsnPlatformComboBox;
        private System.Windows.Forms.Label SteamUsernameLabel;
        private System.Windows.Forms.ComboBox GameType;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}