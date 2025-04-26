namespace Matrix
{
    ///----------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Class holding the colors used in the application.
    /// </summary>
    internal static class Colors
    {
        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// If 000, there will be no influence of the red on the resulting color.
        /// You can choose from 000 to 255.
        /// </summary>
        private const string RED_BYTE = "000";
        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// If 000, there will be no influence of the blue on the resulting color.
        /// You can choose from 000 to 255.
        /// </summary>
        private const string BLUE_BYTE = "000";

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Struct containing colors.
        /// </summary>
        public struct Color
        {
            public static string White = $"\x1B[38;2;255;255;255m";
            public static string Tail1 = $"\x1B[38;2;{RED_BYTE};255;{BLUE_BYTE}m"; // Lightest
            public static string Tail2 = $"\x1B[38;2;{RED_BYTE};240;{BLUE_BYTE}m";
            public static string Tail3 = $"\x1B[38;2;{RED_BYTE};225;{BLUE_BYTE}m";
            public static string Tail4 = $"\x1B[38;2;{RED_BYTE};210;{BLUE_BYTE}m";
            public static string Tail5 = $"\x1B[38;2;{RED_BYTE};195;{BLUE_BYTE}m";
            public static string Tail6 = $"\x1B[38;2;{RED_BYTE};180;{BLUE_BYTE}m";
            public static string Tail7 = $"\x1B[38;2;{RED_BYTE};165;{BLUE_BYTE}m";
            public static string Tail8 = $"\x1B[38;2;{RED_BYTE};150;{BLUE_BYTE}m";
            public static string Tail9 = $"\x1B[38;2;{RED_BYTE};135;{BLUE_BYTE}m";
            public static string Tail10 = $"\x1B[38;2;{RED_BYTE};120;{BLUE_BYTE}m";
            public static string Tail11 = $"\x1B[38;2;{RED_BYTE};105;{BLUE_BYTE}m";
            public static string Tail12 = $"\x1B[38;2;{RED_BYTE};90;{BLUE_BYTE}m";
            public static string Tail13 = $"\x1B[38;2;{RED_BYTE};75;{BLUE_BYTE}m";
            public static string Tail14 = $"\x1B[38;2;{RED_BYTE};60;{BLUE_BYTE}m";
            public static string Tail15 = $"\x1B[38;2;{RED_BYTE};45;{BLUE_BYTE}m";
            public static string Tail16 = $"\x1B[38;2;{RED_BYTE};30;{BLUE_BYTE}m";
            public static string Tail17 = $"\x1B[38;2;{RED_BYTE};15;{BLUE_BYTE}m"; // Darkest
            public static string Reset = "\x1B[0m";
            public static string Black = "\x1B[38;2;0;0;0m";
        }

        ///------------------------------------------------------------------------------------------------------------
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

        //-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// In this list is the order of colors in the "falling" column. Each number represents
        /// the index of a color from the colors list. In our application this means we go from
        /// the white color continously through the fading colors till we reach the tail.
        /// </summary>
        public static List<byte> colorEncoding =
            [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3,
            4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 15, 16, 17, 18];
    }
}
