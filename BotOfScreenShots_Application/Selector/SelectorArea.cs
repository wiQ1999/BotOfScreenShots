using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BotOfScreenShots_Application.Selector
{
    public partial class SelectorArea : Form
    {
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        const int DISTANCE = 10;

        private readonly Brush _color;

        protected Rectangle TopArea { get => new Rectangle(0, 0, ClientSize.Width, DISTANCE); }
        protected Rectangle LeftArea { get => new Rectangle(0, 0, DISTANCE, ClientSize.Height); }
        protected Rectangle BottomArea { get => new Rectangle(0, ClientSize.Height - DISTANCE, ClientSize.Width, DISTANCE); }
        protected Rectangle RightArea { get => new Rectangle(ClientSize.Width - DISTANCE, 0, DISTANCE, ClientSize.Height); }
        protected Rectangle TopLeftArea { get => new Rectangle(0, 0, DISTANCE, DISTANCE); }
        protected Rectangle TopRightArea { get => new Rectangle(ClientSize.Width - DISTANCE, 0, DISTANCE, DISTANCE); }
        protected Rectangle BottomLeftArea { get => new Rectangle(0, ClientSize.Height - DISTANCE, DISTANCE, DISTANCE); }
        protected Rectangle BottomRightArea { get => new Rectangle(ClientSize.Width - DISTANCE, ClientSize.Height - DISTANCE, DISTANCE, DISTANCE); }
        public Rectangle Area { get; private set; }

        public SelectorArea(Brush borderColor)
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            _color = borderColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(_color, new Rectangle(0, 0, ClientSize.Width, 10));
            e.Graphics.FillRectangle(_color, new Rectangle(0, 0, 10, ClientSize.Height));
            e.Graphics.FillRectangle(_color, new Rectangle(ClientSize.Width - 10, 0, 10, ClientSize.Height));
            e.Graphics.FillRectangle(_color, new Rectangle(0, ClientSize.Height - 10, ClientSize.Width, 10));
        }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84)
            {
                var cursor = PointToClient(Cursor.Position);

                if (TopLeftArea.Contains(cursor)) message.Result = new IntPtr(13);
                else if (TopRightArea.Contains(cursor)) message.Result = new IntPtr(14);
                else if (BottomLeftArea.Contains(cursor)) message.Result = new IntPtr(16);
                else if (BottomRightArea.Contains(cursor)) message.Result = new IntPtr(17);
                else if (TopArea.Contains(cursor)) message.Result = new IntPtr(12);
                else if (LeftArea.Contains(cursor)) message.Result = new IntPtr(10);
                else if (RightArea.Contains(cursor)) message.Result = new IntPtr(11);
                else if (BottomArea.Contains(cursor)) message.Result = new IntPtr(15);
            }
        }

        private void SaveArea()
        {
            Area = new Rectangle(Location, Size);
            Close();
        }

        private void SelectorArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
            else if (e.Button == MouseButtons.Right)
                Close();
        }

        private void SelectorArea_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SaveArea();
        }

        private void SelectorArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveArea();
            else if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
