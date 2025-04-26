namespace Matrix
{
    internal static class Colors
    {
        /// <summary>
        /// If 000, there will be no influence of the red on the resulting color.
        /// You can choose from 000 to 255.
        /// </summary>
        private const string RED = "000";
        //private const string RED = "255";

        /// <summary>
        /// If 000, there will be no influence of the blue on the resulting color.
        /// You can choose from 000 to 255.
        /// </summary>
        private const string BLUE = "000";
        //private const string BLUE = "255";

        /// <summary>
        /// Struct containing colors.
        /// </summary>
        public struct Color
        {
            public static string White = $"\x1B[38;2;255;255;255m";
            public static string Tail1 = $"\x1B[38;2;{RED};255;{BLUE}m"; // Lightest
            public static string Tail2 = $"\x1B[38;2;{RED};240;{BLUE}m";
            public static string Tail3 = $"\x1B[38;2;{RED};225;{BLUE}m";
            public static string Tail4 = $"\x1B[38;2;{RED};210;{BLUE}m";
            public static string Tail5 = $"\x1B[38;2;{RED};195;{BLUE}m";
            public static string Tail6 = $"\x1B[38;2;{RED};180;{BLUE}m";
            public static string Tail7 = $"\x1B[38;2;{RED};165;{BLUE}m";
            public static string Tail8 = $"\x1B[38;2;{RED};150;{BLUE}m";
            public static string Tail9 = $"\x1B[38;2;{RED};135;{BLUE}m";
            public static string Tail10 = $"\x1B[38;2;{RED};120;{BLUE}m";
            public static string Tail11 = $"\x1B[38;2;{RED};105;{BLUE}m";
            public static string Tail12 = $"\x1B[38;2;{RED};90;{BLUE}m";
            public static string Tail13 = $"\x1B[38;2;{RED};75;{BLUE}m";
            public static string Tail14 = $"\x1B[38;2;{RED};60;{BLUE}m";
            public static string Tail15 = $"\x1B[38;2;{RED};45;{BLUE}m";
            public static string Tail16 = $"\x1B[38;2;{RED};30;{BLUE}m";
            public static string Tail17 = $"\x1B[38;2;{RED};15;{BLUE}m"; // Darkest
            public static string Reset = "\x1B[0m";
            public static string Black = "\x1B[38;2;0;0;0m";
        }

        /// <summary>
        /// List of colors. 
        /// </summary>
        public static List<string> colors = [
            Color.White,
            Color.Tail1,
            Color.Tail2,
            Color.Tail3,
            Color.Tail4,
            Color.Tail5,
            Color.Tail6,
            Color.Tail7,
            Color.Tail8,
            Color.Tail9,
            Color.Tail10,
            Color.Tail11,
            Color.Tail12,
            Color.Tail13,
            Color.Tail14,
            Color.Tail15,
            Color.Tail16,
            Color.Tail17,
            Color.Reset,
            ];

        public static List<byte> colorEncoding = 
            [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 
            10, 11, 12, 13, 14, 15, 15, 16, 17, 18];
        //public static List<byte> colorEncoding = [0,1,1, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, 1, 1, 18];
    }

}
