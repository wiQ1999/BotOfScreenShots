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

        public SimilarImage(Rectangle WorkArea) : base(WorkArea) 
        {
            _similarityPercent = 75;
        }

        private Bitmap MakeGrayscale(Bitmap Bitmap)
        {
            Bitmap result = new Bitmap(Bitmap.Width, Bitmap.Height);

            for (int x = 0; x < Bitmap.Width; x++)
            {
                for (int y = 0; y < Bitmap.Height; y++)
                {
                    Color BitmapColor = Bitmap.GetPixel(x, y);
                    int grayScale = (int)((BitmapColor.R * 0.3) + (BitmapColor.G * 0.59) + (BitmapColor.B * 0.11));
                    Color myColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    result.SetPixel(x, y, myColor);
                }
            }
            return result;
        }//TO CHANGE!!!@@@

        public override Point? Find(Bitmap searchBitmap)
        {
            base.Find(searchBitmap);

            Bitmap grayMainBitmap = MakeGrayscale(MainBitmap);
            Bitmap graySearchBitmap = MakeGrayscale(MainBitmap);

            int[][] mainImageArray = GetPixelArray(grayMainBitmap);
            int[][] searchImageArray = GetPixelArray(graySearchBitmap);

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

            Bitmap grayMainBitmap = MakeGrayscale(MainBitmap);
            Bitmap graySearchBitmap = MakeGrayscale(MainBitmap);

            int[][] mainImageArray = GetPixelArray(grayMainBitmap);
            int[][] searchImageArray = GetPixelArray(graySearchBitmap);

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
