using System;
using System.Drawing;

namespace BotOfScreenShots_Algorithms
{
    public class SimilarImage : ASearchImage
    {
        private int _similarityPercent;
        public int SimilarityPercent
        {
            get => _similarityPercent;
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Similarity percent must be between 0 and 100 value.");
                _similarityPercent = value;
            }
        }

        public SimilarImage(int x, int y, int width, int height) : base(x, y, width, height)
        {
            _similarityPercent = 50;
        }

        public override Point? Find(Bitmap searchBitmap)
        {
            base.Find(searchBitmap);

            int[][] mainImageArray = GetPixelArray(MainBitmap);
            int[][] searchImageArray = GetPixelArray(searchBitmap);

            for (int yMain = 0, yLength = mainImageArray.Length - searchImageArray.Length + 1; yMain < yLength; yMain++)
            {
                for (int xMain = 0, xLength = mainImageArray[0].Length - searchImageArray[0].Length + 1; xMain < xLength; xMain++)
                {
                    float similarity = 0f;
                    long similarityLineCounter = 0;
                    for (int ySearch = 0; ySearch < searchImageArray.Length; ySearch++)
                    {
                        for (int xSearch = 0; xSearch < searchImageArray[0].Length; xSearch++)
                        {
                            if (mainImageArray[yMain + ySearch][xMain + xSearch] == searchImageArray[ySearch][xSearch])
                                similarityLineCounter++;
                        }
                        similarity = similarityLineCounter / (float)((ySearch + 1) * searchImageArray[0].Length) * 100;
                        if (similarity < _similarityPercent)
                            break;
                    }
                    if (similarity >= _similarityPercent)
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
                    float similarity = 0f;
                    long similarityLineCounter = 0;
                    for (int ySearch = 0; ySearch < searchImageArray.Length; ySearch++)
                    {
                        for (int xSearch = 0; xSearch < searchImageArray[0].Length; xSearch++)
                        {
                            if (mainImageArray[yMain + ySearch][xMain + xSearch] == searchImageArray[ySearch][xSearch])
                                similarityLineCounter++;
                        }
                        similarity = similarityLineCounter / (float)((ySearch + 1) * searchImageArray[0].Length) * 100;
                        if (similarity < _similarityPercent)
                            break;
                    }
                    if (similarity >= _similarityPercent)
                        return new Point(xMain, yMain);
                }
            }

            return null;
        }
    }
}
