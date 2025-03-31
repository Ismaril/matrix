using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace Matrix
{
    public partial class Form1 : Form
    {
        const int WIDTH_OF_APPLICATION_WINDOW = 1920;
        const int HEIGHT_OF_APPLICATION_WINDOW = 1080;
        bool logicInitialized = false;
        Logic logic;
        private readonly Timer _timer = new Timer();

        private readonly int cellWidth = 35; //50;
        private readonly int cellHeight = 45; //50;
        private readonly Font monoFont = new Font("Consolas", 13); //20);
        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Hide(); // Hide mouse
            FormBorderStyle = FormBorderStyle.None;  // Remove border of the window
            _timer.Interval = Consts.GUI_TICK;//(int)Consts.GUI_TICK; // How many milliseconds before next tick.
            _timer.Tick += TimerTick;  // What happens when timer ticks.
            KeyPreview = true;
            KeyDown += KeyArrowsDown;
            DoubleBuffered = true;
            _timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void InitLogic()
        {
            if (logicInitialized)
            {
                return;
            }
            logic = new Logic();
            logicInitialized = true;
        }

        public Form1()
        {
            InitializeComponent();
            InitLogic();
        }

        private void KeyArrowsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
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
            if(e.KeyCode == Keys.F)
            {
                _timer.Interval = Consts.GUI_TICK;
            }
            if (e.KeyCode == Keys.S)
            {
                _timer.Interval = 200;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //DrawString();
            var lines = logic.Main().Split('\n');
            lines = lines.Take(Consts.MATRIX_WIDTH).ToArray();

            base.OnPaint(e);

            //for (int row = 0; row < lines.Length; row++)
            for (int row = 0; row < Consts.MATRIX_HEIGHT; row++)
            {
                string line = lines[row];
                //for (int col = 0; col < line.Length; col++)
                for (int col = 0; col < Consts.MATRIX_WIDTH; col++)
                {
                    //string item = line.Split("\u001b[0m")[col];
                    string item = line.Split(Consts.DELIMETER)[col];
                    if (item == "") continue;
                    float x = col * cellWidth;
                    float y = row * cellHeight;

                    // Your formatted string
                    //string input = c.ToString();
                    string index = item.Substring(0, item.Length - 1);
                    string input = Colors.colors[int.Parse(index)];

                    // Match regex
                    //var match = Regex.Match(input, @"\x1B\[38;2;(\d{1,3});(\d{1,3});(\d{1,3})m(.)");
                    var match = Regex.Match(input, @"\x1B\[38;2;(\d{1,3});(\d{1,3});(\d{1,3})");

                    if (match.Success)
                    {
                        int r = int.Parse(match.Groups[1].Value);
                        int g = int.Parse(match.Groups[2].Value);
                        int b = int.Parse(match.Groups[3].Value);
                        string character = item.Substring(item.Length - 1);

                        // Create a custom brush
                        Brush brush = new SolidBrush(Color.FromArgb(r, g, b));
                        // Example usage with Graphics (inside OnPaint or similar)
                        e.Graphics.DrawString(character, monoFont, brush, x, y);
                        //e.Graphics.DrawString(character, monoFont, textBrush, x, y);
                        brush.Dispose();
                    }
                }
            }
        }
    }
}
