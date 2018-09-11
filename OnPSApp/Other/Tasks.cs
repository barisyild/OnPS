using OnPS.Models;
using OnPS.Platforms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnPS.Other
{
    class Tasks
    {
        private CancellationTokenSource PsnTaskTokenSource;
        private Task PsnTask;
        private int errorCount = 0;
        private ArrayList lastActivityData;
        private ActivityModel activityModel;

        public Tasks(Func<ArrayList, bool> callback, ActivityModel activityModel)
        {
            this.activityModel = activityModel;
            InitializeDiscordTask();
            RunPsnTask(callback);
        }

        private void InitializeDiscordTask()
        {
            Task DiscordTask = new Task(InitializeDiscord);
            DiscordTask.Start();
        }

        private void InitializePsnTask()
        {
            if (PsnTaskTokenSource != null)
            {
                PsnTaskTokenSource.Cancel();
            }
            PsnTaskTokenSource = new CancellationTokenSource();
            CancellationToken PsnTaskToken = PsnTaskTokenSource.Token;
            PsnTask = new Task(InitializePsn, PsnTaskToken);
        }

        public void RunPsnTask(Func<ArrayList, bool> callback)
        {
            if (PsnTask == null || PsnTask.Status == TaskStatus.RanToCompletion)
            {
                InitializePsnTask();
            }
            else if(PsnTask.Status == TaskStatus.Running)
            {
                return;
            }
            PsnTask.ContinueWith((task) =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    PsnTaskTokenSource.Cancel();
                    return;
                }
                if (errorCount >= 3)
                {
                    if (Network.CheckForInternetConnection())
                    {
                        (String, String) TokenData = Platforms.PSN.AuthWithRefreshToken(IniModel.GetPSNRefreshToken());
                        if (TokenData.Item1 == null)
                        {
                            PsnTaskTokenSource.Cancel();
                            MessageBox.Show("An unknown error has occurred. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                            return;
                        }
                        Program.AccessToken = TokenData.Item1;
                        errorCount = 0;
                    }
                    else
                    {
                        PsnTaskTokenSource.Cancel();
                        MessageBox.Show("An unknown error has occurred. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                callback(lastActivityData);
            });
            //PsnTaskTokenSource.Cancel();
            PsnTask.Start();
        }

        private void InitializeDiscord()
        {
            Discord discord = new Discord();
            discord.init(activityModel);
        }

        private void InitializePsn()
        {
            ActivityModel Activity = Platforms.PSN.GetUserActivity(Program.AccessToken);
            if (Activity == null)
            {
                errorCount++;
                return;
            }
            else
            {
                errorCount = 0;
            }
            lastActivityData = Activity.getData();
        }
        
    }
}
