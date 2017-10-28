using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageConverter.ConvertStrategies
{
    public class ToGIFStrategy : BaseToStrategy, IStrategy
    {
        public void Process(string sourcePath, string destinationPath)
        {
            base.Process(sourcePath, destinationPath, ImageFormat.Gif);
        }
    }
}
