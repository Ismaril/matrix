

using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using Timer = System.Windows.Forms.Timer;

namespace Matrix
{
    public partial class Form1 : Form
    {
        const int WIDTH_OF_APPLICATION_WINDOW = 1920;
        const int HEIGHT_OF_APPLICATION_WINDOW = 1080;
        bool logicInitialized = false;
        bool guiMatrixInitialized = false;
        Logic logic;
        private readonly Timer _timer = new Timer();
        private PictureBox _pictureBox;
        int looper = 0;
        public const int MAIN_GRID_WIDTH = 8;
        public const int MAIN_GRID_HEIGHT = 4;
        private const int X_OFFSET_CENTRE_OF_SCREEN = 0;
        private const byte PICTURE_BOX_LOCATION = MAIN_GRID_WIDGET_SIZE + MAIN_GRID_WIDGET_SIZE / 10;
        private const byte MAIN_GRID_WIDGET_SIZE = 80;
        private const string TEXT_PICTUREBOX = "pictureBox";
        private Label[,] gridLabels = new Label[50, 50];

        private readonly int cellWidth = 49;
        private readonly int cellHeight = 53;
        private readonly Font monoFont = new Font("Consolas", 20);
        private readonly Brush textBrush = Brushes.White;
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
            //DrawString();
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
            //InitGuiMatrix();
            //OnPaint(null);
        }
        private void KeyArrowsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
        public void DrawString()
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            //string drawString = "Sample Text";
            string drawString = logic.Main();
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 12);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = 0.0F;
            float y = 0.0F;
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
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
                    //char c = line[col];
                    //if (c == ' ') continue; // Skip spaces if needed
                    string item = line.Split("\u001b[0m")[col];
                    float x = col * cellWidth;
                    float y = row * cellHeight;

                    // Your formatted string
                    //string input = c.ToString();
                    string input = item;

                    // Match regex
                    var match = Regex.Match(input, @"\x1B\[38;2;(\d{1,3});(\d{1,3});(\d{1,3})m(.)");

                    if (match.Success)
                    {
                        int r = int.Parse(match.Groups[1].Value);
                        int g = int.Parse(match.Groups[2].Value);
                        int b = int.Parse(match.Groups[3].Value);
                        string character = match.Groups[4].Value;

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
