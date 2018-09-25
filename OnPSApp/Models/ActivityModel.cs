using OnPS.Models.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Timers;

namespace OnPS.Models
{
    public class ActivityModel
    {
        public event EventHandler OnGameChangedEvent;
        public event EventHandler OnGameCloseEvent;
        public event EventHandler OnPrimaryOnlineStatusChangedEvent;
        public event EventHandler OnOnlineStatusChangedEvent;
        public event EventHandler OnPlatformChangedEvent;
        public event EventHandler OnGameStatusChangedEvent;
        public string npTitleIconUrl;
        public string titleName;
        public string onlineId;
        public string npId;
        public int plus = 0;
        public string _npTitleId;
        public string _onlineStatus;
        public string _primaryOnlineStatus;
        public string _platform;
        public string _gameStatus;
        public string avatarUrl;
        private System.Timers.Timer gameTimeTimer = null;
        public ArrayList RunningGames = new ArrayList();


        public ActivityModel(bool isMain=false)
        {
            if(isMain)
            {
                gameTimeTimer = new System.Timers.Timer();
                gameTimeTimer.Interval = 1000 * 60;
                gameTimeTimer.Elapsed += gameTimeTimer_Elpased;
                gameTimeTimer.Start();
            }
        }

        private void gameTimeTimer_Elpased(object sender, ElapsedEventArgs e)
        {
            foreach(GameData RunningGame in RunningGames)
            {
                String npTitleId = RunningGame.npTitleId;
                String titleName = RunningGame.titleName;
                String platform = RunningGame.platform;
                String npTitleIconUrl = RunningGame.npTitleIconUrl;
                if (npTitleId == null || titleName == null)
                {
                    int idleTime = 0;
                    if (Program.iniFile.KeyExists("idleTime", platform + "_statistics"))
                        idleTime = Convert.ToInt16(Program.iniFile.Read("idleTime", platform + "_statistics"));
                    idleTime++;
                    Program.iniFile.Write("idleTime", idleTime.ToString(), platform + "_statistics");
                }
                else
                {
                    GameStatisticModel gameStatisticModel = new GameStatisticModel(onlineId, platform, npTitleId, titleName, npTitleIconUrl);
                    gameStatisticModel.AddMinute();
                    gameStatisticModel.SaveData();
                }
            }
        }

        public string npTitleId
        {
            get { return _npTitleId; }
            set
            {
                if(value == null && _npTitleId != null)
                {
                    _npTitleId = value;
                    if (OnGameCloseEvent != null)
                    {
                        OnGameCloseEvent(this,EventArgs.Empty);
                    }
                }else if (_npTitleId != value)
                {
                    _npTitleId = value;
                    if (OnGameChangedEvent != null)
                    {
                        OnGameChangedEvent(this, EventArgs.Empty);
                    }
                }
            }
        }
        public string primaryOnlineStatus
        {
            get { return _primaryOnlineStatus; }
            set
            {
                if (_primaryOnlineStatus != value)
                {
                    _primaryOnlineStatus = value;
                    if (OnPrimaryOnlineStatusChangedEvent != null)
                    {
                        OnPrimaryOnlineStatusChangedEvent(this, EventArgs.Empty);
                    }
                }
            }
        }

        public string onlineStatus
        {
            get { return _onlineStatus; }
            set
            {
                if (_onlineStatus != value)
                {
                    _onlineStatus = value;
                    if (OnOnlineStatusChangedEvent != null)
                    {
                        OnOnlineStatusChangedEvent(this, EventArgs.Empty);
                    }
                }
            }
        }

        public string platform
        {
            get { return _platform; }
            set
            {
                if (_platform != value)
                {
                    _platform = value;
                    if (OnPlatformChangedEvent != null)
                    {
                        OnPlatformChangedEvent(this, EventArgs.Empty);
                    }
                }
            }
        }

        public string gameStatus
        {
            get { return _gameStatus; }
            set
            {
                if(_gameStatus != value)
                {
                    _gameStatus = value;
                    if(OnGameChangedEvent != null)
                    {
                        OnGameStatusChangedEvent(this, EventArgs.Empty);
                    }
                }
            }
        }

        public ArrayList getData()
        {
            ArrayList array = new ArrayList();
            var result = this.GetType().GetFields();
            foreach (var item in result)
            {
                if(item.FieldType.ToString().Contains("EventHandler"))
                {
                    continue;
                }
                ArrayList itemArray = new ArrayList();
                itemArray.Add(item.Name);
                itemArray.Add(item.GetValue(this));
                array.Add(itemArray);
            }
            return array;
        }

        public void setData(ArrayList result)
        {
            foreach (ArrayList item in result)
            {
                String name = item[0].ToString();
                if(name.StartsWith("_"))
                {
                    name = name.Substring(1);
                    this.GetType().GetProperty(name).SetValue(this, item[1]);
                }
                else
                {
                    this.GetType().GetField(name).SetValue(this, item[1]);
                }
            }
        }
    }
}
