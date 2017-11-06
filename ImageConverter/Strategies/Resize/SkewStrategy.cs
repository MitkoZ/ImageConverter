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
    internal class SkewStrategy : BaseResizeStrategy, IStrategy
    {
        protected internal Size wantedSize = new Size();

        public SkewStrategy(Parameter parameter)
        {
            ValidateWidthHeight(parameter.Width, parameter.Height);
            this.wantedSize.Width = parameter.Width;
            this.wantedSize.Height = parameter.Height;
        }

        public void Start(string srcPath, string destPath)
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
    }
}
