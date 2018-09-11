using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnPS.Models
{
    class GameViewModel
    {
        public const String DEFAULT = "0";
        public const String PLATFORM_SHORTCUT = "1";
        public const String GAME_NAME_ONLY = "2";

        public static String getName(String titleName, String platform)
        {
            String platformName = PlatformModel.GetPlatformName(platform);
            String ViewName = null;
            switch (IniModel.GetGameView())
            {
                case GameViewModel.DEFAULT:
                    ViewName = titleName + " - " + platformName;
                    break;
                case GameViewModel.PLATFORM_SHORTCUT:
                    ViewName = titleName + " - " + platform;
                    break;
                case GameViewModel.GAME_NAME_ONLY:
                    ViewName = titleName;
                    break;
                default:
                    ViewName = titleName + " - " + platformName;
                    break;
            }
            return ViewName;
        }
    }
}
