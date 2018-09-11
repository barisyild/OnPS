using SteamTheme;

namespace OnPS
{
    partial class Steam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Steam));
            this.steamTheme = new SteamTheme.SteamTheme();
            this.label3 = new System.Windows.Forms.Label();
            this.steamButton2 = new SteamTheme.SteamButton();
            this.steamButton1 = new SteamTheme.SteamButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new SteamTheme.SteamTextBox();
            this.steamSeparator1 = new SteamTheme.SteamSeparator();
            this.cancel = new SteamTheme.SteamButton();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.steamClose1 = new SteamTheme.SteamClose();
            this.username = new SteamTheme.SteamTextBox();
            this.login = new SteamTheme.SteamButton();
            this.steamTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // steamTheme
            // 
            this.steamTheme.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.steamTheme.Colors = new SteamTheme.Bloom[0];
            this.steamTheme.Controls.Add(this.label3);
            this.steamTheme.Controls.Add(this.steamButton2);
            this.steamTheme.Controls.Add(this.steamButton1);
            this.steamTheme.Controls.Add(this.label2);
            this.steamTheme.Controls.Add(this.label1);
            this.steamTheme.Controls.Add(this.password);
            this.steamTheme.Controls.Add(this.steamSeparator1);
            this.steamTheme.Controls.Add(this.cancel);
            this.steamTheme.Controls.Add(this.usernameLabel);
            this.steamTheme.Controls.Add(this.steamClose1);
            this.steamTheme.Controls.Add(this.username);
            this.steamTheme.Controls.Add(this.login);
            this.steamTheme.Customization = "";
            this.steamTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.steamTheme.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.steamTheme.Image = null;
            this.steamTheme.Location = new System.Drawing.Point(0, 0);
            this.steamTheme.Movable = true;
            this.steamTheme.Name = "steamTheme";
            this.steamTheme.NoRounding = false;
            this.steamTheme.Sizable = false;
            this.steamTheme.Size = new System.Drawing.Size(460, 260);
            this.steamTheme.SmartBounds = true;
            this.steamTheme.TabIndex = 0;
            this.steamTheme.Text = "OnPS - Login with Steam";
            this.steamTheme.TransparencyKey = System.Drawing.Color.Empty;
            this.steamTheme.Transparent = false;
            this.steamTheme.Click += new System.EventHandler(this.steamTheme_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Location = new System.Drawing.Point(68, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Don\'t have a steam account?";
            // 
            // steamButton2
            // 
            this.steamButton2.Activated = SteamTheme.SteamButton._Options._true;
            this.steamButton2.Colors = new SteamTheme.Bloom[0];
            this.steamButton2.Customization = "";
            this.steamButton2.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.steamButton2.Image = null;
            this.steamButton2.Location = new System.Drawing.Point(229, 220);
            this.steamButton2.Name = "steamButton2";
            this.steamButton2.NoRounding = false;
            this.steamButton2.Size = new System.Drawing.Size(197, 23);
            this.steamButton2.TabIndex = 12;
            this.steamButton2.Text = "Create a new account...";
            this.steamButton2.Transparent = false;
            this.steamButton2.Click += new System.EventHandler(this.steamButton2_Click);
            // 
            // steamButton1
            // 
            this.steamButton1.Activated = SteamTheme.SteamButton._Options._true;
            this.steamButton1.Colors = new SteamTheme.Bloom[0];
            this.steamButton1.Customization = "";
            this.steamButton1.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.steamButton1.Image = null;
            this.steamButton1.Location = new System.Drawing.Point(229, 183);
            this.steamButton1.Name = "steamButton1";
            this.steamButton1.NoRounding = false;
            this.steamButton1.Size = new System.Drawing.Size(197, 23);
            this.steamButton1.TabIndex = 11;
            this.steamButton1.Text = "I can\'t sıgn ın...";
            this.steamButton1.Transparent = false;
            this.steamButton1.Click += new System.EventHandler(this.steamButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(94, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Need help with sign in?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(56, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Password";
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Colors = new SteamTheme.Bloom[0];
            this.password.Customization = "";
            this.password.Font = new System.Drawing.Font("Verdana", 8F);
            this.password.Image = null;
            this.password.Location = new System.Drawing.Point(118, 88);
            this.password.MaxCharacters = 0;
            this.password.Name = "password";
            this.password.NoRounding = false;
            this.password.Size = new System.Drawing.Size(288, 22);
            this.password.TabIndex = 8;
            this.password.Transparent = true;
            this.password.UsePasswordMask = true;
            // 
            // steamSeparator1
            // 
            this.steamSeparator1.Colors = new SteamTheme.Bloom[0];
            this.steamSeparator1.Customization = "";
            this.steamSeparator1.Font = new System.Drawing.Font("Verdana", 8F);
            this.steamSeparator1.Image = null;
            this.steamSeparator1.Location = new System.Drawing.Point(33, 154);
            this.steamSeparator1.Name = "steamSeparator1";
            this.steamSeparator1.NoRounding = false;
            this.steamSeparator1.Size = new System.Drawing.Size(393, 23);
            this.steamSeparator1.TabIndex = 7;
            this.steamSeparator1.Text = "steamSeparator1";
            this.steamSeparator1.Transparent = false;
            // 
            // cancel
            // 
            this.cancel.Activated = SteamTheme.SteamButton._Options._true;
            this.cancel.Colors = new SteamTheme.Bloom[0];
            this.cancel.Customization = "";
            this.cancel.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.cancel.Image = null;
            this.cancel.Location = new System.Drawing.Point(271, 125);
            this.cancel.Name = "cancel";
            this.cancel.NoRounding = false;
            this.cancel.Size = new System.Drawing.Size(135, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            this.cancel.Transparent = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.usernameLabel.Location = new System.Drawing.Point(32, 53);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(80, 13);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "Account name";
            // 
            // steamClose1
            // 
            this.steamClose1.BackColor = System.Drawing.Color.Transparent;
            this.steamClose1.Location = new System.Drawing.Point(437, 10);
            this.steamClose1.Name = "steamClose1";
            this.steamClose1.Size = new System.Drawing.Size(12, 12);
            this.steamClose1.TabIndex = 4;
            this.steamClose1.Text = "steamClose1";
            this.steamClose1.Click += new System.EventHandler(this.steamClose_Click);
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.Colors = new SteamTheme.Bloom[0];
            this.username.Customization = "";
            this.username.Font = new System.Drawing.Font("Verdana", 8F);
            this.username.Image = null;
            this.username.Location = new System.Drawing.Point(118, 49);
            this.username.MaxCharacters = 0;
            this.username.Name = "username";
            this.username.NoRounding = false;
            this.username.Size = new System.Drawing.Size(288, 22);
            this.username.TabIndex = 3;
            this.username.Transparent = true;
            this.username.UsePasswordMask = false;
            // 
            // login
            // 
            this.login.Activated = SteamTheme.SteamButton._Options._true;
            this.login.Colors = new SteamTheme.Bloom[0];
            this.login.Customization = "";
            this.login.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.login.Image = null;
            this.login.Location = new System.Drawing.Point(118, 125);
            this.login.Name = "login";
            this.login.NoRounding = false;
            this.login.Size = new System.Drawing.Size(135, 23);
            this.login.TabIndex = 2;
            this.login.Text = "Logın";
            this.login.Transparent = false;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // Steam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 260);
            this.Controls.Add(this.steamTheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Steam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Login";
            this.Load += new System.EventHandler(this.SteamTest_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoginKeyUp);
            this.steamTheme.ResumeLayout(false);
            this.steamTheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SteamTheme.SteamTheme steamTheme;
        private SteamTheme.SteamTextBox username;
        private SteamTheme.SteamButton login;
        private SteamTheme.SteamClose steamClose1;
        private System.Windows.Forms.Label usernameLabel;
        private SteamTheme.SteamButton cancel;
        private SteamTheme.SteamSeparator steamSeparator1;
        private SteamTheme.SteamTextBox password;
        private System.Windows.Forms.Label label1;
        private SteamTheme.SteamButton steamButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private SteamTheme.SteamButton steamButton2;
    }
}