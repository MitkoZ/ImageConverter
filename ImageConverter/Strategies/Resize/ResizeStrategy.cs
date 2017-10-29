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
    public class ResizeStrategy : IStrategy
    {
        bool keepAspect = false;
        Size wantedSize = new Size();
        public ResizeStrategy(int width, int height, bool keepAspect)
        {
            if (width < 1)
            {
                throw new ArgumentOutOfRangeException("width", "The new width of the image should be greater than 0");
            }
            else if (height < 1)
            {
                throw new ArgumentOutOfRangeException("height", "The new height of the image should be greater than 0");
            }

            this.wantedSize.Width = width;
            this.wantedSize.Height = height;
            this.keepAspect = keepAspect;
        }
        public void Start(string srcPath, string destPath)
        {
            using (FileStream ifs = new FileStream(srcPath, FileMode.Open))
            {
                Image image = Image.FromStream(ifs);
                Image resizedImage = ResizeImage(image, this.wantedSize, keepAspect);
                using (FileStream ofs = new FileStream(destPath, FileMode.CreateNew))
                {
                    resizedImage.Save(ofs, image.RawFormat);
                }
            }

        }

        private static Image ResizeImage(Image imgToResize, Size wantedSize, bool keepAspect)
        {
            int destWidth = 0;
            int destHeight = 0;
            if (keepAspect == true)
            {
                int sourceWidth = imgToResize.Width;
                int sourceHeight = imgToResize.Height;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = ((float)wantedSize.Width / (float)sourceWidth);
                nPercentH = ((float)wantedSize.Height / (float)sourceHeight);

                nPercent = (nPercentH < nPercentW) ? nPercentH : nPercentW;

                destWidth = (int)(sourceWidth * nPercent);
                destHeight = (int)(sourceHeight * nPercent);
            }
            else
            {
                destWidth = wantedSize.Width;
                destHeight = wantedSize.Height;
            }
            

            Bitmap bitmap = new Bitmap(destWidth, destHeight);
            Graphics graphic = Graphics.FromImage((Image)bitmap);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphic.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            graphic.Dispose();

            return (Image)bitmap;
        }
    }
}
