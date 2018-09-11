namespace OnPS
{
    partial class OnPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnPS));
            this.titleNameLabel = new System.Windows.Forms.Label();
            this.gameStatusLabel = new System.Windows.Forms.Label();
            this.platformLabel = new System.Windows.Forms.Label();
            this.onlineStatusLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleNameLabel
            // 
            this.titleNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.titleNameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleNameLabel.Location = new System.Drawing.Point(1, 288);
            this.titleNameLabel.Name = "titleNameLabel";
            this.titleNameLabel.Size = new System.Drawing.Size(330, 25);
            this.titleNameLabel.TabIndex = 32;
            this.titleNameLabel.Text = "titleNameLabel";
            this.titleNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameStatusLabel
            // 
            this.gameStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameStatusLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gameStatusLabel.Location = new System.Drawing.Point(0, 315);
            this.gameStatusLabel.Name = "gameStatusLabel";
            this.gameStatusLabel.Size = new System.Drawing.Size(333, 20);
            this.gameStatusLabel.TabIndex = 31;
            this.gameStatusLabel.Text = "gameStatusLabel";
            this.gameStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // platformLabel
            // 
            this.platformLabel.BackColor = System.Drawing.Color.Transparent;
            this.platformLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.platformLabel.Location = new System.Drawing.Point(0, 269);
            this.platformLabel.Name = "platformLabel";
            this.platformLabel.Size = new System.Drawing.Size(330, 15);
            this.platformLabel.TabIndex = 29;
            this.platformLabel.Text = "platformLabel";
            this.platformLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // onlineStatusLabel
            // 
            this.onlineStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.onlineStatusLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.onlineStatusLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.onlineStatusLabel.Location = new System.Drawing.Point(2, 350);
            this.onlineStatusLabel.Name = "onlineStatusLabel";
            this.onlineStatusLabel.Size = new System.Drawing.Size(330, 25);
            this.onlineStatusLabel.TabIndex = 28;
            this.onlineStatusLabel.Text = "onlineStatusLabel";
            this.onlineStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.onlineStatusLabel.Click += new System.EventHandler(this.onlineStatusLabel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(180, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(56, 388);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 35;
            this.button3.Text = "Statistics";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(56, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creditsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(336, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // OnPS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(336, 423);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.titleNameLabel);
            this.Controls.Add(this.gameStatusLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.platformLabel);
            this.Controls.Add(this.onlineStatusLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OnPS";
            this.Text = "OnPS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnPS_FormClosed);
            this.Load += new System.EventHandler(this.OnPS_Load);
            this.Shown += new System.EventHandler(this.OnPS_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleNameLabel;
        private System.Windows.Forms.Label gameStatusLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label platformLabel;
        private System.Windows.Forms.Label onlineStatusLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
    }
}