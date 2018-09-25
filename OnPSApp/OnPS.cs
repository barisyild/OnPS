using Newtonsoft.Json.Linq;
using OnPS.Other;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using OnPS.Models;
using OnPS;
using System.Collections;
using System.Threading;
using OnPS.Properties;
using OnPS.Platforms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OnPS
{
    public partial class OnPS : Form
    {
        private Settings settings;
        public ActivityModel activityModel;
        //internal ActivityModel ActivityModel {get => activityModel; set => activityModel = value; }
        private Tasks tasks;



        /// <summary>
        /// The discord client
        /// </summary>


        public OnPS()
        {
            InitializeComponent();
            InitializeNotify();
            InitializeActivityModel();
            InitializeGui();
            InitializeTasks();
        }

        private void InitializeTasks()
        {
            tasks = new Tasks(UpdateActivityModel, activityModel);
        }

        public bool UpdateActivityModel(ArrayList lastActivityData)
        {
            if (!this.IsHandleCreated)
            {
                activityModel.setData(lastActivityData);
            }
            else
            {
                this.Invoke((MethodInvoker)delegate () {
                    activityModel.setData(lastActivityData);
                });
            }
            return true;
        }

        private void InitializeNotify()
        {
            this.Icon = new Icon(this.Icon, new Size(this.Icon.Width * 5, this.Icon.Height * 5));
            Program.notifyIcon.MouseClick += onNotifyClick;
            Program.notifyIcon.MouseDoubleClick += onNotifyClick;
            Program.notifyIcon.BalloonTipClicked += onNotifyClick;
        }

        private void InitializeActivityModel()
        {
            activityModel = Platforms.PSN.GetUserActivity(Program.AccessToken, true); //Initialize Activity.
            activityModel.OnGameChangedEvent += OnGameChangedEvent; //Initialize Events
            activityModel.OnGameCloseEvent += OnGameCloseEvent;
            activityModel.OnOnlineStatusChangedEvent += OnOnlineStatusChangedEvent;
            activityModel.OnPrimaryOnlineStatusChangedEvent += OnPrimaryOnlineStatusChangedEvent;
            activityModel.OnPlatformChangedEvent += OnPlatformChangedEvent;
            activityModel.OnGameStatusChangedEvent += OnGameStatusChangedEvent;
        }

        private void InitializeGui()
        {
            this.gameStatusLabel.Text = "";
            this.onlineStatusLabel.Text = "";
            this.platformLabel.Text = "";
            this.titleNameLabel.Text = "";
            pictureBox1.LoadAsync(activityModel.avatarUrl);
            platformLabel.Text = PlatformModel.GetPlatformName(activityModel.platform);
            onlineStatusLabel.Text = activityModel.onlineStatus;
            if (activityModel.gameStatus != null)
            {
                OnGameStatusChangedEvent(this, new EventArgs());
            }
            if (activityModel.onlineStatus == OnlineStatusModel.ONLINE)
            {
                if (activityModel.npTitleId != null && activityModel.titleName != null)
                {
                    OnGameChangedEvent(this, new EventArgs());
                }
            }
        }

        
        private void OnGameStatusChangedEvent(object sender, EventArgs e)
        {
            gameStatusLabel.Text = activityModel.gameStatus;
        }

        private void OnPlatformChangedEvent(object sender, EventArgs e)
        {
            platformLabel.Text = PlatformModel.GetPlatformName(activityModel.platform);
            if (activityModel.titleName == null && activityModel.npTitleId == null)
            {
                OnGameCloseEvent(this, null);
            }
            else
            {
                OnGameChangedEvent(this, null);
            }
        }

        private void OnOnlineStatusChangedEvent(object sender, EventArgs e)
        {
            onlineStatusLabel.Text = activityModel.onlineStatus;
            Utils.ShowNotify(Program.notifyIcon, PlatformModel.GetPlatformName(activityModel.platform) +  " Online Status: " + activityModel.onlineStatus);
        }

        private void OnPrimaryOnlineStatusChangedEvent(object sender, EventArgs e)
        {
            if(activityModel.primaryOnlineStatus == OnlineStatusModel.ONLINE)
            {
                timer1.Interval = Program.onlineTimerInterval;
            }
            else
            {
                timer1.Interval = Program.offlineTimerInterval;
            }
        }

        public void OnGameChangedEvent(object sender, EventArgs e)
        {
            if(activityModel.titleName == null || activityModel.npTitleId == null)
            {
                return;
            }
            
            titleNameLabel.Text = activityModel.titleName;
            Utils.ShowNotify(Program.notifyIcon, activityModel.titleName);
            String ViewName = GameViewModel.getName(activityModel.titleName, activityModel.platform);
            Program.steam.PlayGame(ViewName);
        }        

        private void OnGameCloseEvent(object sender, EventArgs e)
        {
            
            titleNameLabel.Text = "";
            Utils.ShowNotify(Program.notifyIcon, "No games running.");
            Program.steam.PlayGame(null);
        }

        private void OnPS_Load(object sender, EventArgs e)
        {
            this.SizeChanged += new System.EventHandler(this.OnPS_SizeChanged);
            if (activityModel.primaryOnlineStatus == OnlineStatusModel.ONLINE)
            {
                timer1.Interval = Program.onlineTimerInterval;
            }
            else
            {
                timer1.Interval = Program.offlineTimerInterval;
            }
            timer1.Start();
        }

        private void onNotifyClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            Program.isMinimized = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Steam.isConnected(): " + Program.steam.isConnected());
            Console.WriteLine("Steam.isRunning: " + Program.steam.isRunning);
            Network.SessionCall();
            if (IniModel.GetSteamLoginKey() != null && Program.steam.isConnected() == false && settings == null)
            {
                timer1.Stop();
                SteamConnErr steamConnErr = new SteamConnErr();
                steamConnErr.ShowDialog();
                OnGameChangedEvent(this, null);
                timer1.Start();
            }
            tasks.RunPsnTask(UpdateActivityModel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tasks.RunPsnTask(UpdateActivityModel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            settings = new Settings(this);
            settings.ShowDialog();
            settings.Dispose();
            settings = null;
            OnGameChangedEvent(this, null);
            tasks.RunPsnTask(UpdateActivityModel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameStatistic gameStatistic = new GameStatistic(activityModel.onlineId);
            gameStatistic.ShowDialog();
        }

        private void OnPS_Shown(object sender, EventArgs e)
        {
            if (Program.isMinimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void OnPS_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Program.isMinimized = false;
                if(!Utils.IsWineRunning()) 
                    this.Visible = true; //Wine is glitching this action.
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                Program.isMinimized = true;
                if (!Utils.IsWineRunning())
                    this.Visible = false; //Wine is glitching this action.
                if (Program.minimizedLaunch == false)
                {
                    Utils.ShowNotify(Program.notifyIcon, "Program is still running in the background.");
                }
                Program.minimizedLaunch = false;
            }
        }

        private void steamTheme1_Click(object sender, EventArgs e)
        {

        }

        private void OnPS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Environment.Exit(-1); //For wine compatibility.
        }

        private void onlineStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.onpsapp.com/credits");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.onpsapp.com/search");
        }
    }
}
