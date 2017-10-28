using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.ConvertStrategies
{
    public class ToJPGStrategy : BaseToStrategy, IStrategy
    {
        public void Process(string sourcePath, string destinationPath)
        {
            base.Process(sourcePath, destinationPath, ImageFormat.Jpeg);
        }
    }
}
