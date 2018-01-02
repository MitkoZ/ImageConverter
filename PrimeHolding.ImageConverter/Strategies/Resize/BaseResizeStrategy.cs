using PrimeHolding.ImageConverter.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Strategies.Resize
{
    internal abstract class BaseResizeStrategy
    {
        /// <summary>
        /// Validate user's input for the new image
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <exception cref="InvalidResizeSizeException"></exception>
        protected static void ValidateWidthHeight(int width, int height)
        {
            if (width < 1)
            {
                throw new InvalidResizeSizeException("The new width of the image should be greater than 0");
            }
            else if (height < 1)
            {
                throw new InvalidResizeSizeException("The new height of the image should be greater than 0");
            }
        }
    }
}
