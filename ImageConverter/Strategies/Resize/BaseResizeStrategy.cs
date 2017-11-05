using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Strategies.Resize
{
    public abstract class BaseResizeStrategy : IStrategy
    {
        protected internal Size wantedSize = new Size();
        protected internal Image originalImage { get; set; }

        public BaseResizeStrategy(int width, int height)
        {
            ValidateArguments(width, height);
            this.wantedSize.Width = width;
            this.wantedSize.Height = height;
        }

        public virtual void Start(string srcPath, string destPath)
        {
            using (FileStream ifs = new FileStream(srcPath, FileMode.Open))
            {
                Image originalImage = Image.FromStream(ifs);
                Image resizedImage = ResizeImage(originalImage, this.wantedSize);
                using (FileStream ofs = new FileStream(destPath, FileMode.CreateNew))
                {
                    resizedImage.Save(ofs, originalImage.RawFormat);
                }
            }
        }

        protected internal Image ResizeImage(Image originalImage, Size wantedSize)
        {
            Bitmap bitmap = new Bitmap(wantedSize.Width, wantedSize.Height);
            Graphics graphic = Graphics.FromImage((Image)bitmap);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(originalImage, 0, 0, wantedSize.Width, wantedSize.Height);
            graphic.Dispose();
            return (Image)bitmap;
        }

        private static void ValidateArguments(int width, int height)
        {
            if (width < 1)
            {
                throw new ArgumentOutOfRangeException("width", "The new width of the image should be greater than 0");
            }
            else if (height < 1)
            {
                throw new ArgumentOutOfRangeException("height", "The new height of the image should be greater than 0");
            }
        }
    }
}
