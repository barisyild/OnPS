using OnPS.Models;
using OnPS.Other;
using OnPS.Platforms;
using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace OnPS
{
    static class Program
    {
        public static String SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/OnPS/";
        public const String VERSION = "1.0.0.0";
        public static NotifyIcon notifyIcon;
        public static bool steamAvailable = false;
        private static Mutex mutex;
        public static IniFile iniFile;
        public static String AccessToken;
        public static Platforms.Steam steam;
        private static string appGuid = "54075e0d-205c-4a4d-b8a5-b5ec41677177";
        public static bool isMinimized { get { return _isMinimized; } set
            {
                try
                {
                    notifyIcon.Visible = value;
                }
                catch(Exception)
                {

                }
                _isMinimized = value;
            }
        }
        private static bool _isMinimized = false;
        public static bool minimizedLaunch = false;
        public static String ClientID = null;
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        [STAThread]
        static void Main(string[] args)
        {
            ClientID = Utils.GetClientID();
            steam = new Platforms.Steam();
            foreach (string s in args)
            {
                if (s == "-minimized")
                {
                    isMinimized = true;
                    minimizedLaunch = true;
                }
                if (s == "-console")
                {
                    AllocConsole();
                }
            }
            bool exists = System.IO.Directory.Exists(SavePath);

            if (!exists)
                System.IO.Directory.CreateDirectory(SavePath);
            using (mutex = new Mutex(false, appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("OnPS already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                iniFile = new IniFile(SavePath + @"\");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate (object senderr, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) {
                   return true; // Always accept
                }; //Wine Fix!
                InitializeNotify();
                //AllocConsole();
                Application.Run(new Loader());
            }
        }

        private static void InitializeNotify()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon.Visible = false;
            notifyIcon.Text = "OnPS";
        }

        public static void Restart()
        {
            mutex.ReleaseMutex();
            Application.Restart();
        }
    }
}
