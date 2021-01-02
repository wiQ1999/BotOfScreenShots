using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace BotOfScreenShots_Algorithms
{
    public abstract class ASearchImage
    {
        public Rectangle _WorkArea;

        private Bitmap _MainBitmap;

        public Rectangle WorkArea { get => _WorkArea; }

        public Bitmap MainBitmap { get => _MainBitmap; private set => _MainBitmap = value; }

        public ASearchImage(Rectangle WorkArea)
        {
            _WorkArea = WorkArea;
            //_MainBitmap = TakeScreenShot(WorkArea);
        }

        public static Bitmap TakeScreenShot(Rectangle areaToCapture)
        {
            Bitmap result = new Bitmap(areaToCapture.Width, areaToCapture.Height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(areaToCapture.X, areaToCapture.Y, 0, 0, areaToCapture.Size);
            }
            return result;
        }

        public virtual Point? Find(Bitmap searchBitmap)
        {
            if (_WorkArea.Width < searchBitmap.Width || _WorkArea.Height < searchBitmap.Height)
                throw new Exception("Szukany element nie może być większy od obszaru wyszukiwania.");
            _MainBitmap = TakeScreenShot(_WorkArea);
            return null;
        }

        public virtual Point? Find(Bitmap searchBitmap, Rectangle newMainBitmap)
        {
            if (newMainBitmap.Width < searchBitmap.Width || newMainBitmap.Height < searchBitmap.Height)
                throw new Exception("Szukany element nie może być większy od obszaru wyszukiwania.");
            if (_WorkArea.Top > newMainBitmap.Top || _WorkArea.Bottom < newMainBitmap.Bottom || _WorkArea.Left > newMainBitmap.Left || _WorkArea.Right < newMainBitmap.Right)
                throw new Exception("Nowy obszar wyszuiwania nie znajduje się w obszarze roboczym.");
            _MainBitmap = TakeScreenShot(newMainBitmap);
            return null;
        }

        protected int[][] GetPixelArray(Bitmap bitmap)
        {
            var result = new int[bitmap.Height][];
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            for (int y = 0; y < bitmap.Height; ++y)
            {
                result[y] = new int[bitmap.Width];
                Marshal.Copy(bitmapData.Scan0 + y * bitmapData.Stride, result[y], 0, result[y].Length);
            }
            bitmap.UnlockBits(bitmapData);

            return result;
        }
    }
}
