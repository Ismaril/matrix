namespace Matrix
{
    ///----------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Class holding the logic of the application.
    /// </summary>
    internal class Logic
    {
        /// <summary>
        /// Matrix holding the characters. Each position in the matrix will be occupied.
        /// </summary>
        private readonly string[] _matrix = new string[Consts.MATRIX_WIDTH * Consts.MATRIX_HEIGHT];
        /// <summary>
        /// Dictionary holding the indexes of the leading characters in the matrix. 
        /// By leading character we mean the first character in a column which is falling down.
        /// (White colored character.)
        /// </summary>
        private readonly Dictionary<int, int> _leadingCharacterIdxs = [];
        /// <summary>
        /// Boolean variable to determine whether the matrix is initialized or not.
        /// </summary>
        private bool _isMatrixInitialized = false;
        /// <summary>
        /// Array holding the color encodings with characters. Each position in the array will be occupied.
        /// </summary>
        private string[] _characterArrayColored = new string[Consts.MATRIX_SIZE];

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Fill the matrix with characters (strings). Each position in the matrix will be occupied.
        /// In the console application the row always ends with newline character.
        /// </summary>
        private void InitializeMatrix()
        {
            if (_isMatrixInitialized)
            {
                return;
            }

            for (int i = 0; i < Consts.MATRIX_SIZE; i++)
            {
                // At the end of each row add a newline character.
                if (i % Consts.MATRIX_WIDTH == Consts.MATRIX_WIDTH - 1)
                {
                    _matrix[i] = "\n";
                }
                // Else add a random character from the alphabet.
                else
                {
                    int random_index = new Random().Next(0, Consts.ALPHABET.Length);
                    string character = Consts.ALPHABET[random_index].ToString();
                    _matrix[i] = character;
                }
            }
            _isMatrixInitialized = true;
        }

        private string Print()
        {
            return string.Join("", _characterArrayColored);
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        private async void ColoriseMatrix()
        {
            //string[] characterArrayColored = new string[Consts.MATRIX_SIZE];

            // Idx = index
            // Idxs = indexes
            for (int heightIdx = 0; heightIdx < Consts.MATRIX_HEIGHT; heightIdx++)
            {
                for (int widthIdx = 0; widthIdx < Consts.MATRIX_WIDTH; widthIdx++)
                {
                    // Index from the perspective of whole matrix. Increments by 1.
                    int matrixIdx = heightIdx * Consts.MATRIX_WIDTH + widthIdx;

                    // Newline chars just always move without any other action
                    if (_matrix[matrixIdx] == "\n")
                    {
                        _characterArrayColored[matrixIdx] = "\n";
                    }
                    // If there is a leading character activated at a given column
                    // and we are at a row which holds the leading character, we therefore get
                    // an XY coordinates of a leading character in the matrix and we can compute the offests
                    // also for the trailing characters and assign them relevant colors.
                    else if (_leadingCharacterIdxs[widthIdx] != Consts.COMPLETE_COLUMN_HIDDEN
                        && _leadingCharacterIdxs[widthIdx] == heightIdx)
                    {
                        ChosseRightColor(matrixIdx, _leadingCharacterIdxs[widthIdx] == Consts.COMPLETE_COLUMN_HIDDEN);
                    }
                    //If no previous conditions match, just leave the character black.
                    else
                    {
                        int lastItem = Colors.colorEncoding.Count - 1;
                        byte blackColor = Colors.colorEncoding[lastItem];
                        _characterArrayColored[matrixIdx] = blackColor + _matrix[matrixIdx] + Consts.DELIMETER;
                    }
                }   
            }
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// At the 0 position (row) always choose the leading color. (Default white)
        /// Then choose a trailing color which with each other character fades away.
        /// The mechanism in this method is able to determine how far we are in the matrix,
        /// (at wich matrix index) and therefore can choose how many trailing characters to color.
        /// With this we are able to exclude index out of array exception when we are "looking back"
        /// with the offset when the leading character starts falling from the upper side of the matrix.
        /// </summary>
        /// <param name="matrixIdx"></param>
        /// <returns></returns>
        private void ChosseRightColor(int matrixIdx, bool hidden)
        {
            for (int i = 0; i < Consts.NR_CHARACTERS_RAIN_DROP; i++)
            {
                // Select an appropriate traling color
                if (matrixIdx >= Consts.MATRIX_WIDTH * i && i > 0)
                {
                    int offsetRows = matrixIdx - Consts.MATRIX_WIDTH * i;
                    _characterArrayColored[offsetRows] = Colors.colorEncoding[i] + _matrix[offsetRows] + Consts.DELIMETER;
                }
                // The leading character always gets the leading color (default white)
                else if (i == 0)
                {
                    _characterArrayColored[matrixIdx] = Colors.colorEncoding[i] + _matrix[matrixIdx] + Consts.DELIMETER;
                }
                // TODO: Try to refactor that a black is here
                // If no previous conditions match, just leave the character black.
                //else if (hidden)
                //{
                //    int lastItem = Colors.colorEncoding.Count - 1;
                //    byte blackColor = Colors.colorEncoding[lastItem];
                //    _characterArrayColored[matrixIdx] = blackColor + _matrix[matrixIdx] + Consts.DELIMETER;
                //}
            }
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Update the leading characters positions in the matrix. The leading character is 
        /// </summary>
        private void UpdateLeadCharactersPositions()
        {
            for (int widthIndex = 0; widthIndex < Consts.MATRIX_WIDTH; widthIndex++)
            {
                Random random = new Random();
                bool indexInitialised = _leadingCharacterIdxs.TryGetValue(widthIndex, out int startPosition);
                bool addCharacter = random.Next(0, 100) < Consts.PERCENTAGE_OF_SPAWN_CHANCE;

                // This first if block is executed only during the very first round, when a dictionary is empty.
                // Meaning this if block is going to be executed only 1x in the whole runtime.
                if (!indexInitialised)
                {
                    addCharacter = random.Next(0, 100) < 1;
                    if (addCharacter)
                    {
                        _leadingCharacterIdxs.Add(widthIndex, Consts.START_POSITION);
                    }
                    else
                    {
                        _leadingCharacterIdxs.Add(widthIndex, Consts.COMPLETE_COLUMN_HIDDEN);
                    }
                }
                // This if block is executed once the dictionary already holds values at all positions.
                // Meaning this block is going to be executed always except the first run.
                else if (indexInitialised)
                {
                    // Whether a leading character should spawn at a given column.
                    if (_leadingCharacterIdxs[widthIndex] == Consts.COMPLETE_COLUMN_HIDDEN && addCharacter)
                    {
                        _leadingCharacterIdxs[widthIndex] = Consts.START_POSITION;
                    }
                    // Whether a leading character at a given column should move one row down.
                    else if (_leadingCharacterIdxs[widthIndex] != Consts.COMPLETE_COLUMN_HIDDEN)
                    {
                        _leadingCharacterIdxs[widthIndex] = _leadingCharacterIdxs[widthIndex] += 1;
                    }
                    // Whether a leading character is out of the matrix. (Fell completely
                    // down)
                    if (_leadingCharacterIdxs[widthIndex] > Consts.MATRIX_HEIGHT)
                    {
                        _leadingCharacterIdxs[widthIndex] = Consts.COMPLETE_COLUMN_HIDDEN;
                    }
                }
            }
        }

        /// -----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Main method of the logic which is called from the GUI.
        /// </summary>
        /// <returns></returns>
        public string Main()
        {
            InitializeMatrix();
            UpdateLeadCharactersPositions();
            ColoriseMatrix();
            //Thread.Sleep(2);
            return Print();
        }
    }
}
