using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageConverter.Strategies.Convert
{
    public class ToGIFStrategy : BaseToStrategy, IStrategy
    {
        public void Start(string srcPath, string destPath)
        {
            base.Start(srcPath, destPath, ImageFormat.Gif);
        }
    }
}
