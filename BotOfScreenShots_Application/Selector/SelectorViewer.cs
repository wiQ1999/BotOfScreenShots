using System;
using System.Drawing;
using System.Windows.Forms;

namespace BotOfScreenShots_Application.Selector
{
    public partial class SelectorViewer : Form
    {
        public static string FileName;

        public SelectorViewer(Bitmap bitmap)
        {
            InitializeComponent();
            FileName = string.Empty;
            DisplayBitmap(bitmap);
        }

        private void DisplayBitmap(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            if (width > 460 || height > 205)
            {
                float scale = Math.Min(460 / (float)width, 205 / (float)height);
                width = (int)Math.Ceiling(width * scale);
                height = (int)Math.Ceiling(height * scale);
                ViewPictureBox.Image = new Bitmap(bitmap, new Size(width, height));
                return;
            }

            ViewPictureBox.Image = bitmap;
        }

        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            FileName = FileNameTextBox.Text;
        }
    }
}
