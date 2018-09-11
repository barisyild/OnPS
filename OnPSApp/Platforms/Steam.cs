using OnPS;
using OnPS.Models;
using SteamKit2;
using SteamKit2.Discovery;
using SteamKit2.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnPS.Platforms
{
    class Steam
    {
        private readonly SteamClient steamClient;
        private readonly SteamFriends steamFriends;
        public readonly CallbackManager manager;
        private readonly SteamUser steamUser;
        private const uint LoginID = 1245;
        private byte[] sentryHash;
        public bool isRunning;

        private string username, password;
        private string authCode, twoFactorAuth;

        public Steam()
        {
            var cellid = 0u;

            // if we've previously connected and saved our cellid, load it.
            if (File.Exists("cellid.txt"))
            {
                if (!uint.TryParse(File.ReadAllText("cellid.txt"), out cellid))
                {
                    Console.WriteLine("Error parsing cellid from cellid.txt. Continuing with cellid 0.");
                    cellid = 0;
                }
                else
                {
                    Console.WriteLine($"Using persisted cell ID {cellid}");
                }
            }

            var configuration = SteamConfiguration.Create(b =>
               b.WithCellID(cellid)
                .WithServerListProvider(new FileStorageServerListProvider("servers_list.bin")));

            // create our steamclient instance
            steamClient = new SteamClient(configuration);
            // create the callback manager which will route callbacks to function calls
            manager = new CallbackManager(steamClient);

            // get the steamuser handler, which is used for logging on after successfully connecting
            steamUser = steamClient.GetHandler<SteamUser>();
            steamFriends = steamClient.GetHandler<SteamFriends>();

            // register a few callbacks we're interested in
            // these are registered upon creation to a callback manager, which will then route the callbacks
            // to the functions specified
            manager.Subscribe<SteamClient.ConnectedCallback>(OnConnected);
            manager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);
            manager.Subscribe<SteamUser.AccountInfoCallback>(OnAccountInfo);
            manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
            manager.Subscribe<SteamUser.LoggedOffCallback>(OnLoggedOff);
            manager.Subscribe<SteamUser.LoginKeyCallback>(OnLoginKey);

            // this callback is triggered when the steam servers wish for the client to store the sentry file
            manager.Subscribe<SteamUser.UpdateMachineAuthCallback>(OnMachineAuth);

            //RunCallback();
        }

        public void Connect(String user, String pass)
        {
            isRunning = true;
            username = user;
            password = pass;
            steamClient.Connect();
            while (isRunning)
            {
                // in order for the callbacks to get routed, they need to be handled by the manager
                manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }
        }

        public void Disconnect()
        {
            steamClient.Disconnect();

        }

        public bool isConnected()
        {
            return steamClient.IsConnected;
        }

        public bool PlayGame(string gameName)
        {
            var request = new ClientMsgProtobuf<CMsgClientGamesPlayed>(EMsg.ClientGamesPlayed);

            var gamePlayed = new CMsgClientGamesPlayed.GamePlayed();
            if (!string.IsNullOrEmpty(gameName))
            {
                gamePlayed.game_id = new GameID()
                {
                    AppType = GameID.GameType.Shortcut,
                    ModID = uint.MaxValue
                };
                gamePlayed.game_extra_info = gameName;
            }

            request.Body.games_played.Add(gamePlayed);
            if (!steamClient.IsConnected)
                return false;

            steamClient.Send(request);
            return true;
        }

        private void OnConnected(SteamClient.ConnectedCallback callback)
        {
            Console.WriteLine("Connected to Steam! Logging in '{0}'...", username);

            if (File.Exists("sentry.bin"))
            {
                // if we have a saved sentry file, read and sha-1 hash it
                byte[] sentryFile = File.ReadAllBytes("sentry.bin");
                sentryHash = CryptoHelper.SHAHash(sentryFile);
            }

            String loginKey = IniModel.GetSteamLoginKey();

            SteamUser.LogOnDetails logonDetails = new SteamUser.LogOnDetails();
            logonDetails.Username = username;
            logonDetails.Password = password;
            logonDetails.LoginKey = loginKey;
            logonDetails.LoginID = LoginID;
            logonDetails.AuthCode = authCode;
            logonDetails.TwoFactorCode = twoFactorAuth;
            logonDetails.SentryFileHash = sentryHash;
            logonDetails.ShouldRememberPassword = true;
            try
            {
                steamUser.LogOn(logonDetails);
            }catch(ArgumentException)
            {
                isRunning = false;
            }
            
        }

        private void OnAccountInfo(SteamUser.AccountInfoCallback callback)
        {
            // before being able to interact with friends, you must wait for the account info callback
            // this callback is posted shortly after a successful logon

            // at this point, we can go online on friends, so lets do that
            //steamFriends.SetPersonaState(EPersonaState.Online);
        }

        private void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            // after recieving an AccountLogonDenied, we'll be disconnected from steam
            // so after we read an authcode from the user, we need to reconnect to begin the logon flow again

            Console.WriteLine("Disconnected from Steam, reconnecting in 5...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            steamClient.Connect();
        }

        private void OnLoginKey(SteamUser.LoginKeyCallback callback)
        {
            if (string.IsNullOrEmpty(callback?.LoginKey))
            {
                return;
            }
            IniModel.SetSteamLoginKey(callback.LoginKey);
            steamUser.AcceptNewLoginKey(callback);
        }

        private void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            bool isSteamGuard = callback.Result == EResult.AccountLogonDenied;
            bool is2FA = callback.Result == EResult.AccountLoginDeniedNeedTwoFactor;

            if (isSteamGuard || is2FA)
            {
                Console.WriteLine("This account is SteamGuard protected!");

                if (is2FA)
                {
                    twoFactorAuth = Microsoft.VisualBasic.Interaction.InputBox("Please enter your 2 factor auth code from your authenticator app.",
                       "2 Factor Authentication",
                       "",
                       0,
                       0);
                }
                else
                {
                    authCode = Microsoft.VisualBasic.Interaction.InputBox("Please enter the auth code sent to the email at " + callback.EmailDomain,
                       "Authentication",
                       "",
                       0,
                       0);
                }

                return;
            }

            if (callback.Result != EResult.OK)
            {
                isRunning = false;
                return;
            }

            Console.WriteLine("Successfully logged on!");
            IniModel.SetSteamUsername(username);
            steamFriends.SetPersonaState(EPersonaState.Online);
            // at this point, we'd be able to perform actions on Steam
        }

        private void OnLoggedOff(SteamUser.LoggedOffCallback callback)
        {
            Console.WriteLine("Logged off of Steam: {0}", callback.Result);
        }

        private void OnMachineAuth(SteamUser.UpdateMachineAuthCallback callback)
        {
            if (callback == null)
            {
                return;
            }

            int fileSize;
            String SentryFilePath = "sentry.bin";

            try
            {
                using (FileStream fileStream = File.Open(SentryFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fileStream.Seek(callback.Offset, SeekOrigin.Begin);
                    fileStream.Write(callback.Data, 0, callback.BytesToWrite);
                    fileSize = (int)fileStream.Length;

                    fileStream.Seek(0, SeekOrigin.Begin);
                    using (SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider())
                    {
                        sentryHash = sha.ComputeHash(fileStream);
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    File.Delete(SentryFilePath);
                }
                catch
                {
                    // Ignored, we can only try to delete faulted file at best
                }

                return;
            }

            // Inform the steam servers that we're accepting this sentry file
            steamUser.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
            {
                JobID = callback.JobID,
                FileName = callback.FileName,
                BytesWritten = callback.BytesToWrite,
                FileSize = fileSize,
                Offset = callback.Offset,
                Result = EResult.OK,
                LastError = 0,
                OneTimePassword = callback.OneTimePassword,
                SentryFileHash = sentryHash
            });
        }
    }
}
