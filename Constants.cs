namespace Matrix
{
    ///----------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// This file contains all the constants used in the application.
    /// </summary>
    internal static class Consts
    {
        // ------------------------------------------------------------------------------------------------------------
        // MATRIX SIZE
        /// <summary>
        /// The width of the matrix. Meaning how many columns we have in the matrix.
        /// </summary>
        public const int MATRIX_WIDTH = 71;
        /// <summary>
        /// The height of the matrix. Meaning how many rows we have in the matrix.
        /// </summary>
        public const int MATRIX_HEIGHT = 71;
        /// <summary>
        /// The size of the matrix. Meaning how many cells we have in the matrix.
        /// </summary>
        public const int MATRIX_SIZE = MATRIX_WIDTH * MATRIX_HEIGHT;
        public const int CELL_WIDTH = 55; //50;
        public const int CELL_HEIGHT = 55; //50;
        public const int FONT_SIZE = 25;

        // ------------------------------------------------------------------------------------------------------------
        // GUI FRAME SPEED
        /// <summary>
        /// Used to determine the speed of the game in milliseconds. For example,
        /// 1000 means we will see a new graphics frame every second.
        /// </summary>
        public const int GUI_TICK_DEFAULT = 35;
        /// <summary>
        /// For docs see <see cref="GUI_TICK_DEFAULT"/>
        /// </summary>
        public const int GUI_TICK_SLOW = 200;


        // ------------------------------------------------------------------------------------------------------------
        // CODES TO DETERMINE IF A COLUMN IS HIDDEN OR READY TO "START FALLING"
        /// <summary>
        /// Our code (-1) representing that a given column is hidden.
        /// </summary>
        public const int COMPLETE_COLUMN_HIDDEN = -1;
        /// <summary>
        /// Our code (0) representing that at a given column the rain drop is at the top with the first character
        /// and ready to start falling further down.
        /// </summary>
        public const int START_POSITION = 0;

        // ------------------------------------------------------------------------------------------------------------
        // MISC
        /// <summary>
        /// Delimiter used to separate the colored characters in the matrix.
        /// </summary>
        public const string DELIMETER = ";";
        /// <summary>
        /// The string used to generate the random characters in the matrix.
        /// </summary>
        public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        /// <summary>
        /// The percentage of spawn chance for a rain drop.
        /// </summary>
        /// <remarks>In our implementation the chance is calculated for each empty column each loop.</remarks>
        public const float PERCENTAGE_OF_SPAWN_CHANCE = 15;
        /// <summary>
        /// Number of characters in a rain drop. (Rain drop which created the fading effect)
        /// </summary>
        /// <remarks>Current implementation does not have dinamic adjustment based on the lentgh
        /// of rain drop. If you want to make the raindrop longer, increment the number here and
        /// add more colors at relevant places.</remarks>
        public const int NR_CHARACTERS_RAIN_DROP = 34;


        // ------------------------------------------------------------------------------------------------------------
        // APPLICATION WINDOW
        /// <summary>
        /// Width of the application window in pixels.
        /// </summary>
        public const int WIDTH_OF_APPLICATION_WINDOW = 1920;
        /// <summary>
        /// Height of the application window in pixels.
        /// </summary>
        public const int HEIGHT_OF_APPLICATION_WINDOW = 1080;

    }
}
