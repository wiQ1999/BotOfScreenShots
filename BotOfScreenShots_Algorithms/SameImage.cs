using System.Drawing;

namespace BotOfScreenShots_Algorithms
{
    public class SameImage : ASearchImage
    {
        public SameImage(int x, int y, int width, int height) : base(x, y, width, height) { }

        public override Point? Find(Bitmap searchBitmap)
        {
            base.Find(searchBitmap);

            int[][] mainImageArray = GetPixelArray(MainBitmap);
            int[][] searchImageArray = GetPixelArray(searchBitmap);

            for (int yMain = 0, yLength = mainImageArray.Length - searchImageArray.Length + 1; yMain < yLength; yMain++)
            {
                for (int xMain = 0, xLength = mainImageArray[0].Length - searchImageArray[0].Length + 1; xMain < xLength; xMain++)
                {
                    bool isMatch = true;
                    for (int ySearch = 0; ySearch < searchImageArray.Length; ySearch++)
                    {
                        for (int xSearch = 0; xSearch < searchImageArray[0].Length; xSearch++)
                        {
                            if (mainImageArray[yMain + ySearch][xMain + xSearch] != searchImageArray[ySearch][xSearch])
                            {
                                isMatch = false;
                                break;
                            }
                        }
                        if (!isMatch)
                            break;
                    }
                    if (isMatch)
                        return new Point(xMain, yMain);
                }
            }
            return null;
        }

        public override Point? Find(Bitmap searchBitmap, Rectangle newMainBitmap)
        {
            base.Find(searchBitmap, newMainBitmap);

            int[][] mainImageArray = GetPixelArray(MainBitmap);
            int[][] searchImageArray = GetPixelArray(searchBitmap);

            for (int yMain = 0, yLength = mainImageArray.Length - searchImageArray.Length + 1; yMain < yLength; yMain++)
            {
                for (int xMain = 0, xLength = mainImageArray[0].Length - searchImageArray[0].Length + 1; xMain < xLength; xMain++)
                {
                    bool isMatch = true;
                    for (int ySearch = 0; ySearch < searchImageArray.Length; ySearch++)
                    {
                        for (int xSearch = 0; xSearch < searchImageArray[0].Length; xSearch++)
                        {
                            if (mainImageArray[yMain + ySearch][xMain + xSearch] != searchImageArray[ySearch][xSearch])
                            {
                                isMatch = false;
                                break;
                            }
                        }
                        if (!isMatch)
                            break;
                    }
                    if (isMatch)
                        return new Point(xMain, yMain);
                }
            }
            return null;
        }
    }
}
