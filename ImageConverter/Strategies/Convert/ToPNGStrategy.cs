using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Strategies.Convert
{
    public class ToPNGStrategy : BaseToStrategy, IStrategy
    {
        public void Start(string srcPath, string destPath)
        {
            base.Start(srcPath, destPath, ImageFormat.Png);
        }
    }
}
