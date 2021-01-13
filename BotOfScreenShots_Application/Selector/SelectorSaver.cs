using BotOfScreenShots_Algorithms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BotOfScreenShots_Application.Selector
{
    class SelectorSaver : SelectorArea
    {
        private readonly string _path;
        private Bitmap _bitmapToSave;
        private Form _viewer;

        public SelectorSaver(Brush borderColor, string path) : base(borderColor)
        {
            _path = path;
        }

        protected override void SaveArea()
        {
            base.SaveArea();

            Visible = false;

            _bitmapToSave = ASearchImage.TakeScreenShot(Area);
            _viewer = new SelectorViewer(_bitmapToSave);

            //CreateForm(_bitmapToSave);

            _viewer.ShowDialog();
            if (_viewer.DialogResult == DialogResult.OK)
            {
                try
                {
                    _bitmapToSave.Save(_path + "\\" + SelectorViewer.FileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                _viewer.Close();
        }

        private void CreateForm(Bitmap bitmapToShow)
        {
            int distance = 12;
            int width = bitmapToShow.Width;
            int height = bitmapToShow.Height;
            Bitmap view = bitmapToShow;

            //resize
            if (width > 800 || height > 800)
            {
                float scale = Math.Min(800 / (float)width, 800 / (float)height);
                width = (int)Math.Ceiling(width * scale);
                height = (int)Math.Ceiling(height * scale);
                view = new Bitmap(bitmapToShow, new Size(width, height));
            }

            //form size
            _viewer.Width = width + distance * 2;
            _viewer.Height = height + distance * 3 + 23;

            //initialize controls
            Label formatLabel = new Label();
            Button saveButton = new Button();
            Button cancelButton = new Button();
            PictureBox viewPictureBox = new PictureBox();

            //constrols size
            formatLabel.Width = 40;
            //_viewer.fi fileNameTextBox.Width = _viewer.Width - (formatLabel.Width + saveButton.Width + cancelButton.Width + distance * 4);
            viewPictureBox.Width = _viewer.Width - distance * 3;
            viewPictureBox.Height = _viewer.Height - distance * 6 - 23;

            //name
            formatLabel.Text = ".png";
            saveButton.Text = "Save";
            cancelButton.Text = "Cancel";

            //location
            //formatLabel.Location = new Point(fileNameTextBox.Right, fileNameTextBox.Top);
            saveButton.Location = new Point(formatLabel.Right, formatLabel.Top);
            cancelButton.Location = new Point(saveButton.Right + distance, saveButton.Top);
            //viewPictureBox.Location = new Point(distance, fileNameTextBox.Bottom + distance);

            //destination
            saveButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
            viewPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            viewPictureBox.Image = view;

            //add controls
            //_viewer.Controls.Add(fileNameTextBox);
            _viewer.Controls.Add(formatLabel);
            _viewer.Controls.Add(saveButton);
            _viewer.Controls.Add(cancelButton);
            _viewer.Controls.Add(viewPictureBox);
        }//not used
    }
}
