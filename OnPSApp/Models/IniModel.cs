using OnPS;
using OnPS.Models;
using System;

namespace OnPS.Models
{
    class IniModel
    {
        private const String PSN = "PSN";
        private const String STEAM = "STEAM";
        private const String REFRESH_TOKEN = "RT";
        private const String PLATFORM = "P";
        private const String LOGIN_KEY = "LK";
        private const String USERNAME = "U";
        private const String GAME_VIEW = "GV";

        /* GetGameView */

        public static String GetGameView()
        {
            if (!Program.iniFile.KeyExists(GAME_VIEW, STEAM))
            {
                Program.iniFile.Write(GAME_VIEW, GameViewModel.DEFAULT.ToString(), STEAM);
            }
            return Program.iniFile.Read(GAME_VIEW, STEAM);
        }

        public static void DeleteGameView()
        {
            Program.iniFile.DeleteKey(GAME_VIEW, STEAM);
        }

        public static void SetGameView(String value)
        {
            Program.iniFile.Write(GAME_VIEW, value, STEAM);
        }

        /* GetPSNPlatform */

        public static String GetPSNPlatform()
        {
            if (!Program.iniFile.KeyExists(PLATFORM, PSN) || PlatformModel.GetPlatformName(Program.iniFile.Read(PLATFORM, PSN)) == null)
            {
                Program.iniFile.Write(PLATFORM, PlatformModel.PS4, PSN);
            }
            return Program.iniFile.Read(PLATFORM, PSN);
        }

        public static void DeletePSNPlatform()
        {
            Program.iniFile.DeleteKey(PLATFORM, PSN);
        }

        public static void SetPSNPlatform(String value)
        {
            if (PlatformModel.GetPlatformName(value) == null)
            {
                Program.iniFile.Write(PLATFORM, PlatformModel.PS4, PSN);
            }
            else
            {
                Program.iniFile.Write(PLATFORM, value, PSN);
            }
        }

        /* PSNRefreshToken */

        public static String GetPSNRefreshToken()
        {
            if (!Program.iniFile.KeyExists(REFRESH_TOKEN, PSN))
                return null;
            return Program.iniFile.Read(REFRESH_TOKEN, PSN);
        }

        public static void DeletePSNRefreshToken()
        {
            Program.iniFile.DeleteKey(REFRESH_TOKEN, PSN);
        }

        public static void SetPSNRefreshToken(String value)
        {
            Program.iniFile.Write(REFRESH_TOKEN, value, PSN);
        }

        /* SteamUsername */

        public static String GetSteamUsername()
        {
            if (!Program.iniFile.KeyExists(USERNAME, STEAM))
                return null;
            return Program.iniFile.Read(USERNAME, STEAM);
        }

        public static void DeleteSteamUsername()
        {
            Program.iniFile.DeleteKey(USERNAME, STEAM);
        }

        public static void SetSteamUsername(String value)
        {
            Program.iniFile.Write(USERNAME, value, STEAM);
        }

        /* SteamLoginKey */

        public static String GetSteamLoginKey()
        {
            if (!Program.iniFile.KeyExists(LOGIN_KEY, STEAM))
                return null;
            return Program.iniFile.Read(LOGIN_KEY, STEAM);
        }

        public static void DeleteSteamLoginKey()
        {
            Program.iniFile.DeleteKey(LOGIN_KEY, STEAM);
        }

        public static void SetSteamLoginKey(String value)
        {
            Program.iniFile.Write(LOGIN_KEY, value, STEAM);
        }

    }
}
