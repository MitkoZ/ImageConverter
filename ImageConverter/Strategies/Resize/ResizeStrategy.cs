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
    public class ResizeStrategy : BaseResizeStrategy, IStrategy
    {
        public ResizeStrategy(int width, int height) : base(width, height)
        {}

        public override void Start(string srcPath, string destPath)
        {
            base.Start(srcPath, destPath);
        }
    }
}
