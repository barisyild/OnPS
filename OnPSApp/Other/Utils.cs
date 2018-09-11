using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace OnPS.Other
{
    class Utils
    {
        public static string CalculateMinuteToTime(int minute)
        {
            String text = "";
            TimeSpan t = TimeSpan.FromMinutes(minute);
            if(t.Days >= 1)
            {
                if (t.Days == 1)
                    text += t.Days + " day ";
                else
                    text += t.Days + " days ";
            }
            if (t.Hours >= 1)
            {
                if (t.Hours == 1)
                    text += t.Hours + " Hour ";
                else
                    text += t.Hours + " Hours ";
            }
            if (t.Minutes >= 1)
            {
                if (t.Minutes == 1)
                    text += t.Minutes + " Minute ";
                else
                    text += t.Minutes + " Minutes ";
            }
            return text;
        }

        public static bool IsWineRunning()
        {
            return (Process.GetProcessesByName("winlogon").Count() == 0);
        }


        public static bool ShowNotify(NotifyIcon notifyIcon, String text, String title = "OnPS")
        {
            if (text == null)
                return false;
            notifyIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon.ShowBalloonTip(10000, title, text, ToolTipIcon.None);
            return true;
        }

        public static void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("OnPS", "\""+Application.ExecutablePath + "\" -minimized");
            }
            else
            {
                registryKey.DeleteValue("OnPS");
            }
        }

        public static bool StartupEnabled()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if(registryKey.GetValue("OnPS") == null)
            {
                return false;
            }
            return true;
        }

        public static string MD5(string String)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(String);
            btr = md5.ComputeHash(btr);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte ba in btr)
            {
                stringBuilder.Append(ba.ToString("x2").ToLower());
            }
            return stringBuilder.ToString();
        }

        public static String GetClientID()
        {
            Random random = new Random();
            long microTime = GetMilliSeconds();
            //int randomNumber = random.Next(0, (int)microTime);
            //return MD5(microTime.ToString() + "_" + randomNumber);
            return "-1";
        }

        public static long  GetMilliSeconds()
        {
            return new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
        }
    }
}
