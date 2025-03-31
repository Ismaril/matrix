namespace Matrix
{
    internal static class Consts
    {
        // ------------------------------------------------------------------------------------------------------------
        // MATRIX SIZE
        /// <summary>
        /// The width of the matrix. Meaning how many columns we have in the matrix.
        /// </summary>
        public const int MATRIX_WIDTH = 115; //80;
        /// <summary>
        /// The height of the matrix. Meaning how many rows we have in the matrix.
        /// </summary>
        public const int MATRIX_HEIGHT = 73; //65;
        /// <summary>
        /// The size of the matrix. Meaning how many cells we have in the matrix.
        /// </summary>
        public const int MATRIX_SIZE = MATRIX_WIDTH * MATRIX_HEIGHT;

        // ------------------------------------------------------------------------------------------------------------
        // GUI FRAME SPEED
        /// <summary>
        /// Used to determine the speed of the game in milliseconds. For example,
        /// 1000 means we will see a new graphics frame every second.
        /// </summary>
        /// <remarks>For our purpouses 1ms, because in current implementation
        /// the algorithm is slower anyway, so the real update is going to be slower.
        /// </remarks>
        public const int GUI_TICK = 16;

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
        public const int NR_CHARACTERS_RAIN_DROP = 17+9+2;

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

        public const string DELIMETER = ";";

    }
}
