using OnPS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnPS.Models;
using OnPS.Other;
using OnPS.Platforms;

namespace OnPS
{
    public partial class Settings : Form
    {
        private OnPS OnPS;
        private String SampleGameName = @"flOw™";

        public Settings(OnPS OnPSm)
        {
            InitializeComponent();
            OnPS = OnPSm;
        }

        public Settings()
        {
        }

        private void initGameTypes()
        {
            String titleName = OnPS.ActivityModel.titleName;
            String platform = PsnPlatformComboBox.SelectedItem.ToString();
            if (titleName == null || OnPS.ActivityModel.platform != platform)
            {
                titleName = SampleGameName;
            }
            var dict = new Dictionary<int, string>();
            dict.Add(int.Parse(GameViewModel.DEFAULT), titleName + " - " + PlatformModel.GetPlatformName(platform));
            dict.Add(int.Parse(GameViewModel.PLATFORM_SHORTCUT), titleName + " - " + platform);
            dict.Add(int.Parse(GameViewModel.GAME_NAME_ONLY), titleName);
            GameType.DataSource = new BindingSource(dict, null);
            GameType.DisplayMember = "Value";
            GameType.ValueMember = "Key";
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if(Program.steamAvailable)
            {
                SteamLogButton.Text = "Logout";
            }
            else
            {
                SteamLogButton.Text = "Login";
            }
            checkBox1.Checked = Utils.StartupEnabled();
            PsnUsernameLabel.Text = OnPS.ActivityModel.onlineId;
            SteamUsernameLabel.Text = IniModel.GetSteamUsername();
            PsnPlatformComboBox.Text = IniModel.GetPSNPlatform();
            initGameTypes();
            GameType.SelectedIndex = int.Parse(IniModel.GetGameView());
            PsnPlatformComboBox.SelectedIndexChanged += new System.EventHandler(this.PsnPlatformComboBox_SelectedIndexChanged);
            GameType.SelectedIndexChanged += new System.EventHandler(this.GameType_SelectedIndexChanged);
            checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
        }

        private void PsnLogoutButton_Click(object sender, EventArgs e)
        {
            IniModel.DeletePSNRefreshToken();
            Program.Restart();
        }

        private void SteamLogoutButton_Click(object sender, EventArgs e)
        {
            if(Program.steamAvailable)
            {
                IniModel.DeleteSteamLoginKey();
                Program.steam.Disconnect();
                Program.steam = new Platforms.Steam();
                Program.steamAvailable = false;
            }
            else
            {
                Steam steamLogin = new Steam();
                steamLogin.ShowDialog();
                steamLogin.Dispose();
                steamLogin = null;
                Program.steamAvailable = Program.steam.isConnected();
            }
           this.Close();
        }

        private void PsnPlatformComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IniModel.SetPSNPlatform(PsnPlatformComboBox.SelectedItem.ToString());
            /*if(OnPS.timer1.Enabled == false)
            {
                OnPS.timer1.Stop();
            }
            try
            {
                if (OnPS.backgroundWorker1.IsBusy == true)
                {
                    OnPS.backgroundWorker1.CancelAsync();
                }
            }
            catch(Exception)
            {

            }

            try
            {
                OnPS.backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception)
            {

            }
            OnPS.timer1.Start();
            initGameTypes();*/
        }

        private void GameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(GameType.SelectedValue.ToString());
            IniModel.SetGameView(GameType.SelectedValue.ToString());
            //OnPS.OnGameChangedEvent(OnPS, null);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Utils.RegisterInStartup(checkBox1.Checked);
        }
    }
}
