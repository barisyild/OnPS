using DiscordRPC;
using OnPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnPS.Platforms
{
    class Discord
    {
        private static int DiscordPipe = -1;
        private static string ClientID = "476530101937504256";
        private static DiscordRpcClient client;
        private string lastTitleId;
        private static RichPresence presence = new RichPresence()
        {
            Assets = new Assets()
            {

            }
        };
        public Discord()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void init(ActivityModel activityModel)
        {
            client = new DiscordRpcClient(ClientID, true, DiscordPipe);
            presence.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow
            };
            client.SetPresence(presence);
            client.Initialize();
            while (client != null)
            {
                if (client != null)
                    client.Invoke();

                Thread.Sleep(1000);

                if (activityModel.titleName == null || activityModel.npTitleId == null)
                {
                    try
                    {
                        client.ClearPresence();
                    }
                    catch (ObjectDisposedException)
                    {

                    }
                    continue;
                }

                if (lastTitleId != activityModel.npTitleId)
                {
                    try
                    {
                        client.ClearPresence();
                    }
                    catch (ObjectDisposedException)
                    {

                    }
                    client.Dispose();
                    client = new DiscordRpcClient(ClientID, true, DiscordPipe);
                    presence.Timestamps = new Timestamps()
                    {
                        Start = DateTime.UtcNow
                    };
                    client.Initialize();
                    lastTitleId = activityModel.npTitleId;
                }
                presence.Details = GameViewModel.getName(activityModel.titleName, activityModel.platform);
                presence.Assets.LargeImageKey = activityModel.npTitleId.ToLower();
                presence.Assets.LargeImageText = activityModel.titleName;
                if (activityModel.gameStatus != "")
                    presence.State = activityModel.gameStatus;
                else
                    presence.State = null;
                client.SetPresence(presence);
            }
        }

        public void Dispose()
        {
            client.Dispose();
            client = null;
        }
    }
}
