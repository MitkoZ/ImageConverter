using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Strategies.Convert
{
    public class ToJPGStrategy : BaseToStrategy, IStrategy
    {
        public void Start(string srcPath, string destPath)
        {
            base.Start(srcPath, destPath, ImageFormat.Jpeg);
        }
    }
}
