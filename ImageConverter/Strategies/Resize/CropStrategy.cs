using ImageConverter.Interfaces;
using System.Drawing;
using System.IO;
using System;
using ImageConverter.Exceptions;

namespace ImageConverter.ResizeStrategies
{
    public class CropStrategy : IStrategy
    {
        private int left, top, right, bottom;

        public CropStrategy(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public void Start(string srcPath, string destPath)
        {
            using (FileStream ifs = new FileStream(srcPath, FileMode.Open))
            {
                Bitmap bitmap = new Bitmap(ifs);
                Rectangle rectangle = Rectangle.FromLTRB(this.left, this.top, this.right, this.bottom);
                ValidateCropDimensions(rectangle, bitmap);
                Bitmap newBitmap = bitmap.Clone(rectangle, bitmap.PixelFormat);
                using (FileStream ofs = new FileStream(destPath, FileMode.CreateNew))
                {
                    newBitmap.Save(ofs, bitmap.RawFormat);
                }
            }

        }

        private void ValidateCropDimensions(Rectangle rectangle, Bitmap bitmap)
        {
            if (rectangle.Left < 0)
            {
                throw new InvalidCropDimensionsException("The left coordinate should not be outside of the image and/or less than zero");
            }
            else if (rectangle.Left >= rectangle.Right)
            {
                throw new InvalidCropDimensionsException("The left coordinate should not be greater than or equal to the right coordinate");
            }
            else if (rectangle.Top < 0)
            {
                throw new InvalidCropDimensionsException("The top coordinate should not be outside of the image and/or less than zero");
            }
            else if (rectangle.Top >= rectangle.Bottom)
            {
                throw new InvalidCropDimensionsException("The top coordinate should not be greater than or equal to the bottom coordinate");
            }
            else if (rectangle.Bottom > bitmap.Height)
            {
                throw new InvalidCropDimensionsException("The bottom coordinate should not be greater than the height of the image");
            }
            else if (rectangle.Right > bitmap.Width)
            {
                throw new InvalidCropDimensionsException("The right coordinate should not be greater than the size of the image");
            }
        }
    }
}
