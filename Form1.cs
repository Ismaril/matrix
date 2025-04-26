using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace Matrix
{
    ///----------------------------------------------------------------------------------------------------------------
    /// <inheritdoc />
    public partial class Form1 : Form
    {
        private bool _islogicInitialized = false;
        private Logic _logic;
        private readonly Timer _timer = new();
        private readonly Font _monoFont = new("Consolas", Consts.FONT_SIZE);

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Constructor for the Form1 class. It initializes the form and sets up the logic.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitLogic();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Hide(); // Hide mouse
            FormBorderStyle = FormBorderStyle.None;  // Remove border of the window
            _timer.Interval = Consts.GUI_TICK_DEFAULT; // How many milliseconds before next tick.
            _timer.Tick += TimerTick;  // What happens when timer ticks.
            KeyPreview = true;
            KeyDown += KeyArrowsDown;
            DoubleBuffered = true;
            _timer.Start();
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initialize the logic of the application.
        /// </summary>
        private void InitLogic()
        {
            if (_islogicInitialized)
            {
                return;
            }
            _logic = new Logic();
            _islogicInitialized = true;
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Key event handler for the form. It handles the key events for the form,
        /// in other words, it handles what hapens when a key on keyboard is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyArrowsDown(object sender, KeyEventArgs e)
        {
            // Teminate the application
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            // Pause the application
            if (e.KeyCode == Keys.P)
            {
                if (_timer.Enabled)
                {
                    _timer.Stop();
                }
                else
                {
                    _timer.Start();
                }
            }

            // Change the speed of the application
            if (e.KeyCode == Keys.F)
            {
                _timer.Interval = Consts.GUI_TICK_DEFAULT;
            }

            // Change the speed of the application
            if (e.KeyCode == Keys.S)
            {
                _timer.Interval = Consts.GUI_TICK_SLOW;
            }
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Override the OnPaint method to draw the matrix on the form.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var lines = _logic.Main().Split('\n');
            lines = lines.Take(Consts.MATRIX_WIDTH).ToArray();

            base.OnPaint(e);

            for (int row = 0; row < Consts.MATRIX_HEIGHT; row++)
            {
                string line = lines[row];
                for (int col = 0; col < Consts.MATRIX_WIDTH; col++)
                {
                    string item = line.Split(Consts.DELIMETER)[col];
                    if (item == "") continue;
                    float x = col * Consts.CELL_WIDTH;
                    float y = row * Consts.CELL_HEIGHT;

                    // Your formatted string
                    string index = item.Substring(0, item.Length - 1);
                    string input = Colors.colors[int.Parse(index)];

                    // Match regex
                    var match = Regex.Match(input, @"\x1B\[38;2;(\d{1,3});(\d{1,3});(\d{1,3})");

                    if (match.Success)
                    {
                        int red = int.Parse(match.Groups[1].Value);
                        int green = int.Parse(match.Groups[2].Value);
                        int blue = int.Parse(match.Groups[3].Value);
                        string character = item.Substring(item.Length - 1);

                        // Create a custom brush
                        Brush brush = new SolidBrush(Color.FromArgb(red, green, blue));
                        // Example usage with Graphics (inside OnPaint or similar)
                        e.Graphics.DrawString(character, _monoFont, brush, x, y);
                        //e.Graphics.DrawString(character, monoFont, textBrush, x, y);
                        brush.Dispose();
                    }
                }
            }
        }
    }
}
