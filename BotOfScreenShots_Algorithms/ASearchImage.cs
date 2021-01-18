using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace BotOfScreenShots_Algorithms
{
    public abstract class ASearchImage
    {
        private Bitmap _mainBitmap;
        private Rectangle _workArea;

        public Rectangle WorkArea { get => _workArea; }
        public Bitmap MainBitmap { get => _mainBitmap; private set => _mainBitmap = value; }

        public ASearchImage(Rectangle WorkArea)
        {
            _workArea = WorkArea;
            //_MainBitmap = TakeScreenShot(WorkArea);
        }

        public static Bitmap TakeScreenShot(Rectangle areaToCapture)
        {
            Bitmap result = new Bitmap(areaToCapture.Width, areaToCapture.Height, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(areaToCapture.X, areaToCapture.Y, 0, 0, areaToCapture.Size);
            }
            return result;
        }

        public virtual Point? Find(Bitmap searchBitmap)
        {
            if (_workArea.Width < searchBitmap.Width || _workArea.Height < searchBitmap.Height)
                throw new Exception("Szukany element nie może być większy od obszaru wyszukiwania.");
            _mainBitmap = TakeScreenShot(_workArea);
            return null;
        }

        public virtual Point? Find(Bitmap searchBitmap, Rectangle newMainBitmap)
        {
            if (newMainBitmap.Width < searchBitmap.Width || newMainBitmap.Height < searchBitmap.Height)
                throw new Exception("Szukany element nie może być większy od obszaru wyszukiwania.");
            if (_workArea.Top > newMainBitmap.Top || _workArea.Bottom < newMainBitmap.Bottom || _workArea.Left > newMainBitmap.Left || _workArea.Right < newMainBitmap.Right)
                throw new Exception("Nowy obszar wyszuiwania nie znajduje się w obszarze roboczym.");
            _mainBitmap = TakeScreenShot(newMainBitmap);
            return null;
        }

        protected int[][] GetPixelArray(Bitmap bitmap)
        {
            var result = new int[bitmap.Height][];
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            for (int y = 0; y < bitmap.Height; y++)
            {
                result[y] = new int[bitmap.Width];
                Marshal.Copy(bitmapData.Scan0 + y * bitmapData.Stride, result[y], 0, result[y].Length);
            }
            bitmap.UnlockBits(bitmapData);

            return result;
        }
    }
}
