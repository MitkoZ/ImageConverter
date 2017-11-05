using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Strategies.Resize
{
    public class KeepAspectStrategy : BaseResizeStrategy, IStrategy
    {
        public KeepAspectStrategy(int width, int height) : base(width, height)
        {}

        public override void Start(string srcPath, string destPath)
        {
            using (FileStream ifs = new FileStream(srcPath, FileMode.Open))
            {
                this.originalImage = Image.FromStream(ifs);
            }
            int sourceWidth = originalImage.Width;
            int sourceHeight = originalImage.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)wantedSize.Width / (float)sourceWidth);
            nPercentH = ((float)wantedSize.Height / (float)sourceHeight);

            nPercent = (nPercentH < nPercentW) ? nPercentH : nPercentW;

            this.wantedSize.Width = (int)(sourceWidth * nPercent);
            this.wantedSize.Height = (int)(sourceHeight * nPercent);
            base.Start(srcPath, destPath);
        }
    }
}
