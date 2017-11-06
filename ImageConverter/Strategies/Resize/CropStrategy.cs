using ImageConverter.Interfaces;
using System.Drawing;
using System.IO;
using System;
using ImageConverter.Exceptions;

namespace ImageConverter.Strategies.Resize
{
    internal class CropStrategy : IStrategy
    {
        private int x, y, width, height;

        public CropStrategy(Parameter parameter)
        {
            this.x = parameter.X;
            this.y = parameter.Y;
            this.width = parameter.Width;
            this.height = parameter.Height;
        }

        public void Start(string srcPath, string destPath)
        {
            using (FileStream ifs = new FileStream(srcPath, FileMode.Open))
            {
                Bitmap bitmap = new Bitmap(ifs);
                Rectangle rectangle = new Rectangle(this.x, this.y, this.width, this.height);
                ValidateCropDimensions(rectangle, bitmap);
                Bitmap croppedBitmap = bitmap.Clone(rectangle, bitmap.PixelFormat);
                using (FileStream ofs = new FileStream(destPath, FileMode.CreateNew))
                {
                    croppedBitmap.Save(ofs, bitmap.RawFormat);
                }
            }
        }

        private void ValidateCropDimensions(Rectangle rectangle, Bitmap bitmap)
        {
            if (rectangle.X < 0)
            {
                throw new InvalidCropDimensionsException("The X coordinate should not be outside of the image and/or less than zero");
            }
            else if (rectangle.X + width > bitmap.Width)
            {
                throw new InvalidCropDimensionsException("The X coordinate summed with the passed width is greater than the image's width.");
            }
            else if (rectangle.Y < 0)
            {
                throw new InvalidCropDimensionsException("The Y coordinate should not be outside of the image and/or less than zero");
            }
            else if (rectangle.Y + height > bitmap.Height)
            {
                throw new InvalidCropDimensionsException("The Y coordinate summed with the passed height is greater than the image's height.");
            }
            else if (rectangle.X > bitmap.Width)
            {
                throw new InvalidCropDimensionsException("The X coordinate should not be outside of the image's dimensions");
            }
            else if (rectangle.Y > bitmap.Height)
            {
                throw new InvalidCropDimensionsException("The Y coordinate should not be outside of the image's dimensions");
            }
        }
    }
}
