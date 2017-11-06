using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Strategies.Resize
{
    internal abstract class BaseResizeStrategy
    {
        protected static void ValidateWidthHeight(int width, int height)
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
