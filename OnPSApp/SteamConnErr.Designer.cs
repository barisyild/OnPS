namespace OnPS
{
    partial class SteamConnErr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SteamConnErr));
            this.steamTheme1 = new SteamTheme.SteamTheme();
            this.steamButton1 = new SteamTheme.SteamButton();
            this.label2 = new System.Windows.Forms.Label();
            this.steamButton2 = new SteamTheme.SteamButton();
            this.steamTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // steamTheme1
            // 
            this.steamTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.steamTheme1.Colors = new SteamTheme.Bloom[0];
            this.steamTheme1.Controls.Add(this.steamButton1);
            this.steamTheme1.Controls.Add(this.label2);
            this.steamTheme1.Controls.Add(this.steamButton2);
            this.steamTheme1.Customization = "";
            this.steamTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.steamTheme1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.steamTheme1.Image = null;
            this.steamTheme1.Location = new System.Drawing.Point(0, 0);
            this.steamTheme1.MaximumSize = new System.Drawing.Size(267, 132);
            this.steamTheme1.MinimumSize = new System.Drawing.Size(267, 132);
            this.steamTheme1.Movable = true;
            this.steamTheme1.Name = "steamTheme1";
            this.steamTheme1.NoRounding = false;
            this.steamTheme1.Sizable = true;
            this.steamTheme1.Size = new System.Drawing.Size(267, 132);
            this.steamTheme1.SmartBounds = true;
            this.steamTheme1.TabIndex = 0;
            this.steamTheme1.Text = "OnPS - Connection Error";
            this.steamTheme1.TransparencyKey = System.Drawing.Color.Empty;
            this.steamTheme1.Transparent = false;
            this.steamTheme1.Click += new System.EventHandler(this.steamTheme1_Click);
            // 
            // steamButton1
            // 
            this.steamButton1.Activated = SteamTheme.SteamButton._Options._true;
            this.steamButton1.Colors = new SteamTheme.Bloom[0];
            this.steamButton1.Customization = "";
            this.steamButton1.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.steamButton1.Image = null;
            this.steamButton1.Location = new System.Drawing.Point(164, 92);
            this.steamButton1.Name = "steamButton1";
            this.steamButton1.NoRounding = false;
            this.steamButton1.Size = new System.Drawing.Size(61, 23);
            this.steamButton1.TabIndex = 12;
            this.steamButton1.Text = "QUIT";
            this.steamButton1.Transparent = false;
            this.steamButton1.Click += new System.EventHandler(this.steamButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(25, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Could not connect to Steam network.";
            // 
            // steamButton2
            // 
            this.steamButton2.Activated = SteamTheme.SteamButton._Options._true;
            this.steamButton2.Colors = new SteamTheme.Bloom[0];
            this.steamButton2.Customization = "";
            this.steamButton2.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.steamButton2.Image = null;
            this.steamButton2.Location = new System.Drawing.Point(28, 92);
            this.steamButton2.Name = "steamButton2";
            this.steamButton2.NoRounding = false;
            this.steamButton2.Size = new System.Drawing.Size(123, 23);
            this.steamButton2.TabIndex = 1;
            this.steamButton2.Text = "RETRY CONNECTION";
            this.steamButton2.Transparent = false;
            this.steamButton2.Click += new System.EventHandler(this.steamButton2_Click);
            // 
            // SteamConnErr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 132);
            this.Controls.Add(this.steamTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(267, 132);
            this.MinimumSize = new System.Drawing.Size(267, 132);
            this.Name = "SteamConnErr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteamConnectionError";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SteamConnectionError_Load);
            this.steamTheme1.ResumeLayout(false);
            this.steamTheme1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SteamTheme.SteamTheme steamTheme1;
        private SteamTheme.SteamButton steamButton2;
        private SteamTheme.SteamButton steamButton1;
        private System.Windows.Forms.Label label2;
    }
}