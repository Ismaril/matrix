namespace Matrix
{
    internal class Logic
    {
        private readonly string[] matrix = new string[Consts.MATRIX_WIDTH * Consts.MATRIX_HEIGHT];
        private readonly Dictionary<int, int> leadingCharacterIdxs = [];
        private bool isMatrixInitialized = false;

        ///-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Fill the matrix with characters (strings). Each position in the matrix will be occupied.
        /// In the console application the row always ends with newline character.
        /// </summary>
        void InitializeMatrix()
        {
            if (isMatrixInitialized)
                return;

            string alphabet = "01";// "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < Consts.MATRIX_SIZE; i++)
            {
                if (i % Consts.MATRIX_WIDTH == Consts.MATRIX_WIDTH - 1)
                    matrix[i] = "\n";
                else
                {
                    string character = alphabet[new Random().Next(0, alphabet.Length)].ToString();
                    matrix[i] = character;
                }

            }
            isMatrixInitialized = true;
        }

        private void PrintToConsole(string[] matrix)
        {
            Console.Clear();
            Console.Write(Print(matrix));
        }

        private string Print(string[] matrix)
        {
            return string.Join("", matrix);
        }

        private string[] ColoriseMatrix()
        {
            string[] characterArrayColored = new string[Consts.MATRIX_SIZE];

            // Idx = index
            // Idxs = indexes
            for (int heightIdx = 0; heightIdx < Consts.MATRIX_HEIGHT; heightIdx++)
            {
                for (int widthIdx = 0; widthIdx < Consts.MATRIX_WIDTH; widthIdx++)
                {
                    // Index from the perspective of whole matrix. Increments by 1.
                    int matrixIdx = heightIdx * Consts.MATRIX_WIDTH + widthIdx;

                    // Newline chars just always move without any other action
                    if (matrix[matrixIdx] == "\n")
                    {
                        characterArrayColored[matrixIdx] = "\n";
                    }

                    // If there is a leading character activated at a given column
                    // and we are at a row which holds the leading character, we therefore get
                    // an XY coordinates of a leading character in the matrix and we can compute the offests
                    // also for the trailing characters and assign them relevant colors.
                    else if (leadingCharacterIdxs[widthIdx] != Consts.COMPLETE_COLUMN_HIDDEN
                        && leadingCharacterIdxs[widthIdx] == heightIdx)
                    {
                        characterArrayColored = ChosseRightColor(characterArrayColored, matrixIdx);
                    }
                    // If no previous conditions match, just leave the character black.
                    else
                    {
                        characterArrayColored[matrixIdx] = Colors.Color.Black + matrix[matrixIdx] + Colors.Color.Reset;
                        //characterArrayColored[matrixIdx] = matrix[matrixIdx];
                    }
                }   
            }
            return characterArrayColored;
        }

        ///-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// At the 0 position (row) always choose the leading color. (Default white)
        /// Then choose a trailing color which with each other character fades away.
        /// The mechanism in this method is able to determine how far we are in the matrix,
        /// (at wich matrix index) and therefore can choose how many trailing characters to color.
        /// With this we are able to exclude index out of array exception when we are "looking back"
        /// with the offset when the leading character starts falling from the upper side of the matrix.
        /// </summary>
        /// <param name="characterArrayColored"></param>
        /// <param name="matrixIdx"></param>
        /// <returns></returns>
        private string[] ChosseRightColor(string[] characterArrayColored, int matrixIdx)
        {
            for (int i = 0; i < Consts.NR_CHARACTERS_RAIN_DROP; i++)
            {
                if (matrixIdx >= Consts.MATRIX_WIDTH * i && i > 0)
                {
                    int offsetRows = matrixIdx - Consts.MATRIX_WIDTH * i;
                    characterArrayColored[offsetRows] = Colors.colors[i] + matrix[offsetRows] + Colors.Color.Reset;
                }
                // The leading character always gets the leading color (default white)
                else if (i == 0)
                {
                    characterArrayColored[matrixIdx] = Colors.Color.White + matrix[matrixIdx] + Colors.Color.Reset;
                }
            }
            return characterArrayColored;
        }

        void UpdateLeadCharactersPositions()
        {
            for (int widthIndex = 0; widthIndex < Consts.MATRIX_WIDTH; widthIndex++)
            {
                Random random = new Random();

                bool indexInitialised = leadingCharacterIdxs.TryGetValue(widthIndex, out int startPosition);
                bool addCharacter = random.Next(0, 100) < Consts.PERCENTAGE_OF_SPAWN_CHANCE;

                // This first if block is executed only during the very first round, when a dictionary is empty.
                // Meaning this if block is going to be executed only 1x in the whole runtime.
                if (!indexInitialised)
                {
                    if (addCharacter)
                    {
                        leadingCharacterIdxs.Add(widthIndex, Consts.START_POSITION);
                    }
                    else
                    {
                        leadingCharacterIdxs.Add(widthIndex, Consts.COMPLETE_COLUMN_HIDDEN);
                    }
                }
                // This if block is executed once the dictionary already holds values at all positions.
                // Meaning this block is going to be executed always except the first run.
                else if (indexInitialised)
                {
                    // Whether a leading character should spawn at a given column.
                    if (leadingCharacterIdxs[widthIndex] == Consts.COMPLETE_COLUMN_HIDDEN && addCharacter)
                    {
                        leadingCharacterIdxs[widthIndex] = Consts.START_POSITION;
                    }
                    // Whether a leading character at a given column should move one row down.
                    else if (leadingCharacterIdxs[widthIndex] != Consts.COMPLETE_COLUMN_HIDDEN)
                    {
                        leadingCharacterIdxs[widthIndex] = leadingCharacterIdxs[widthIndex] += 1;
                    }
                    // Whether a leading character is out of the matrix. (Fell completely
                    // down)
                    if (leadingCharacterIdxs[widthIndex] > Consts.MATRIX_HEIGHT)
                    {
                        leadingCharacterIdxs[widthIndex] = Consts.COMPLETE_COLUMN_HIDDEN;
                    }
                }
            }
        }
        
        public string Main()
        {
            InitializeMatrix();
            UpdateLeadCharactersPositions();
            string[] x = ColoriseMatrix();
            return Print(x);

        }
        //public void Main()
        //{
        //    while (true)
        //    {
        //        InitializeMatrix();
        //        UpdateLeadCharactersPositions();
        //        string[] x = ColoriseMatrix();
        //        PrintToConsole(x);
        //        Thread.Sleep(1000);
        //    }
        //}
    }
}
