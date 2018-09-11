using System;

namespace OnPS.Models
{
    class PlatformModel
    {
        public const String PS4 = "PS4";
        public const String PS3 = "PS3";
        public const String PSVITA = "PSVITA";

        public static String GetPlatformName(String name)
        {
            switch(name)
            {
                case PS4:
                    return "PlayStation 4";
                case PS3:
                    return "PlayStation 3";
                case PSVITA:
                    return "PlayStation Vita";
                default:
                    return null;
            }
        }
    }
}
