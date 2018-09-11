using OnPS.Models;
using OnPS.Other;
using OnPS.Platforms;
using SteamKit2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnPS
{
    public partial class SteamConnErr : Form
    {
        public SteamConnErr()
        {
            InitializeComponent();
        }

        private void steamButton2_Click(object sender, EventArgs e)
        {
            String username = IniModel.GetSteamUsername();
            if (username == null)
                Program.Restart();
            this.Cursor = Cursors.WaitCursor;
            Program.steam = new Platforms.Steam();
            Program.steam.manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
            Program.steam.manager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);
            Program.steam.Connect(username, "");
            this.Cursor = Cursors.Default;
        }

        private void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            Program.steam.isRunning = false;
            if (callback.Result == EResult.InvalidPassword)
            {
                if(Program.isMinimized)
                    Utils.ShowNotify(Program.notifyIcon, "The connection of your Steam account has been lost.");
                else
                    MessageBox.Show("The connection of your Steam account has been lost.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (callback.Result != EResult.ConnectFailed && callback.Result != EResult.OK)
            {
                MessageBox.Show("An unknown error has occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            this.Close();
        }

        private void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            Program.steam.isRunning = false;
            MessageBox.Show("Could not connect to Steam network, Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void steamButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void steamTheme1_Click(object sender, EventArgs e)
        {

        }

        private void SteamConnectionError_Load(object sender, EventArgs e)
        {
            steamButton2_Click(this, null);
        }
    }
}
