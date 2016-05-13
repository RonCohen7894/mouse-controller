using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mouse_controler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region var

        public int startingPoint_x { get; set; }
        public int GOTO_1_x { get; set; }
        public int GOTO_2_x { get; set; }
        public int GOTO_3_x { get; set; }
        public int GOTO_4_x { get; set; }
        public int repeat { get; set; }
        public string text_1 { get; set; }
        public int text_2 { get; set; }

        public int startingPoint_y { get; set; }
        public int GOTO_1_y { get; set; }
        public int GOTO_2_y { get; set; }
        public int GOTO_3_y { get; set; }
        public int GOTO_4_y { get; set; }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        #endregion

        #region mouse

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        public static void Move(int xDelta, int yDelta)
        {
            mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
        }
        public static void MoveTo(int x, int y)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
        }
        public static void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void LeftDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void LeftUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightDown()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightUp()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        #endregion

        private async void start_Click(object sender, EventArgs e)
        {
            #region set var

            startingPoint_x = int.Parse(SP_X.Text);
            GOTO_1_x = int.Parse(GoTo_1_x.Text);
            GOTO_2_x = int.Parse(GoTo_2_x.Text);
            GOTO_3_x = int.Parse(GoTo_3_x.Text);
            GOTO_4_x = int.Parse(GoTo_4_x.Text);

            startingPoint_y = int.Parse(SP_Y.Text);
            GOTO_1_y = int.Parse(GoTo_1_y.Text);
            GOTO_2_y = int.Parse(GoTo_2_y.Text);
            GOTO_3_y = int.Parse(GoTo_3_y.Text);
            GOTO_4_y = int.Parse(GoTo_4_y.Text);

            repeat = int.Parse(Repeat.Text);
            text_1 = Text_1.Text;
            text_2 = int.Parse(Text_2.Text);

            int i = text_2;

            #endregion;
            await Task.Delay(2000);

            for (int f = 0; f <= repeat; f++)
            {
                Move(startingPoint_x, startingPoint_y);
                LeftClick();
                await Task.Delay(2000);

                Move(GOTO_1_x, GOTO_1_y);
                LeftClick();
                await Task.Delay(2000);

                Move(GOTO_2_x, GOTO_2_y);
                LeftClick();
                await Task.Delay(2000);

                Move(GOTO_3_x, GOTO_3_y);
                LeftClick();
                await Task.Delay(2000);

                SendKeys.SendWait(string.Format("{0} {1}", text_1, i));
                await Task.Delay(1000);

                Move(GOTO_4_x, GOTO_4_y);
                LeftClick();
                await Task.Delay(5000);
            }                      
        }

        private async void GetC_Click(object sender, EventArgs e)
        {
            AllocConsole();
            while (true)
            {
                Console.WriteLine(Cursor.Position.ToString());
                await Task.Delay(200);
                Console.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}

   
