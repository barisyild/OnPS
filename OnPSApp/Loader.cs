using OnPS;
using OnPS.Models;
using OnPS.Other;
using OnPS.Platforms;
using SteamKit2;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnPS
{
    public partial class Loader : Form
    {
        public int connectAttempt = 0;
        public Loader()
        {
            InitializeComponent();
            if (InitializeLoader() == false)
            {
                Environment.Exit(-1);
                return;
            }
            Updater updater = new Updater();
            updater.UpdateAvailable += onUpdateAvailable;
        }

        public void onUpdateAvailable(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("OnPS new version is available now.\nWould you like to update it?", "Update Available",MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                Process.Start("https://www.onpsapp.com/");
                Application.Exit();
            }
        }

        public bool InitializeLoader()
        {
            while (true)
            {
                if (!Network.CheckForInternetConnection())
                {
                    DialogResult result = MessageBox.Show("Please check the internet connection.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if(result == DialogResult.Retry)
                    {
                        continue;
                    }
                    return false;
                }
                return true;
            }
        }


        private void Loader_Shown(object sender, EventArgs e)
        {
            String AccessToken = null;
            String PSNRefreshToken = IniModel.GetPSNRefreshToken();
            if (PSNRefreshToken == null)
            {
                this.Hide();
                PSN login = new PSN();
                login.ShowDialog();
                PSNRefreshToken = IniModel.GetPSNRefreshToken();
            }
            try
            {
                AccessToken = Platforms.PSN.AuthWithRefreshToken(PSNRefreshToken).Item1;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connect PlayStation Network.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            if (IniModel.GetSteamUsername() != null && IniModel.GetSteamLoginKey() != null)
            {
                Program.steam.manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
                Program.steam.manager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);
                Program.steam.Connect(IniModel.GetSteamUsername(), null);
            }
            /*else
            {
                this.Hide();
                SteamLogin steamLogin = new SteamLogin();
                steamLogin.ShowDialog();
            }*/
            Program.AccessToken = AccessToken;
            this.Hide();
            OnPS OnPSClient = new OnPS();
            OnPSClient.ShowDialog();
        }

        private void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            if (this.Visible == false)
                return;
            connectAttempt++;
            if (connectAttempt >= 3)
            {
                MessageBox.Show("Could not connect to Steam network.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.steamAvailable = false;
            }
        }

        private void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            if (this.Visible == false)
                return;
            Program.steam.isRunning = false;
            if (callback.Result != EResult.OK)
            {
                if (Program.isMinimized)
                    Utils.ShowNotify(Program.notifyIcon, "The connection of your Steam account has been lost.");
                else
                    MessageBox.Show("The connection of your Steam account has been lost.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Program.steamAvailable = false;
                IniModel.DeleteSteamLoginKey();
                return;
            }
            else
            {
                Program.steamAvailable = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
