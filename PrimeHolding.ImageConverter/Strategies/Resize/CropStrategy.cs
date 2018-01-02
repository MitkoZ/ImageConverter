using PrimeHolding.ImageConverter.Interfaces;
using System.Drawing;
using System.IO;
using System;
using PrimeHolding.ImageConverter.Exceptions;
using System.Security;
using System.Runtime.InteropServices;

namespace PrimeHolding.ImageConverter.Strategies.Resize
{
    /// <summary>
    /// A strategy that crops an image
    /// </summary>
    internal class CropStrategy : IStrategy
    {
        /// <summary>
        /// Get or set the x starting coordinate for the image cropping
        /// </summary>
        private int x;

        /// <summary>
        /// Get or set the y starting coordinate for the image cropping
        /// </summary>
        private int y;

        /// <summary>
        /// Get or set the width of the cropped image
        /// </summary>
        private int width;

        /// <summary>
        /// Get or set the height of the cropped image
        /// </summary>
        private int height;

        /// <summary>
        /// Setting the necessary paremeters for the crop strategy
        /// </summary>
        /// <param name="x">X starting coordinate of the image cropping</param>
        /// <param name="y">Y starting coordinate of the image cropping</param>
        /// <param name="width">The cropped width of the image (this will be the width of the new image)</param>
        /// <param name="height">The cropped height of the image (this will be the width of the new image)</param>
        public CropStrategy(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <exception cref="InvalidImageFormatException">Path does not point to a supported image format</exception>
        /// <exception cref="InvalidPixelFormatException">Stream contains a PNG image file with a single dimension greater than 65,535 pixels.</exception>
        /// <exception cref="InvalidCropDimensionsException">Input contains invalid X or Y coordinates.</exception>
        /// <exception cref="InvalidPathException">Path is null or invalid</exception>
        /// <exception cref="UnathorizedAccessException">No permission to access this file/directory.</exception>
        /// <exception cref="WrongSaveImageFormatException">Image was saved with the wrong image format.</exception>
        /// <exception cref="FileNotFoundException">The file specified by <paramref name="sourcePath"/> or <paramref name="destinationPath"/> does not exist</exception>
        /// <exception cref="IOException">The file specified by <paramref name="destinationPath"/> already exists</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="OutOfMemoryException">rect is outside of the source bitmap bounds</exception>
        public void Start(string sourcePath, string destinationPath)
        {
            try
            {
                using (FileStream ifs = new FileStream(sourcePath, FileMode.Open))
                {
                    Bitmap bitmap = new Bitmap(ifs);
                    Rectangle rectangle = new Rectangle(this.x, this.y, this.width, this.height);
                    ValidateCropDimensions(rectangle, bitmap);
                    Bitmap croppedBitmap = bitmap.Clone(rectangle, bitmap.PixelFormat);
                    using (FileStream ofs = new FileStream(destinationPath, FileMode.CreateNew))
                    {
                        croppedBitmap.Save(ofs, bitmap.RawFormat);
                    }
                }
            }
            catch (ArgumentNullException argNullEx)
            {
                throw new InvalidPathException("The path cannot be null", argNullEx);
            }
            catch (ArgumentException argEx)
            {
                if (argEx.Message == "Parameter is not valid.")
                {
                    throw new InvalidImageFormatException("The provided path does not point to a supported image format", argEx);
                }
                else if (argEx.Message == "Empty path name is not legal." || argEx.Message == "The path is not of a legal form." || argEx.Message == "Illegal characters in path.")
                {
                    throw new InvalidPathException(argEx.Message, argEx);
                }
                else
                {
                    throw new InvalidPixelFormatException(argEx.Message, argEx);
                }
            }
            //TODO: fix after https://developercommunity.visualstudio.com/users/7602/4d326e2f-b347-40b8-a920-1442608aadd7.html?itemsifollow is ready //catch (OutOfMemoryException)
            //{

            //}
            catch (NotSupportedException notSuppEx)
            {
                throw new InvalidPathException("The provided path is invalid", notSuppEx);
            }
            catch (SecurityException)
            {
                throw new UnathorizedAccessException("You don't have the required permission to access this file/directory.");
            }
            catch (ExternalException)
            {
                throw new WrongSaveImageFormatException("The image was saved with the wrong image format.");
            }
        }

        /// <summary>
        /// Validation of the user's input parameters
        /// </summary>
        /// <param name="rectangle">User's input container</param>
        /// <param name="bitmap">Source image container</param>
        /// <exception cref="InvalidCropDimensionsException"></exception>
        private void ValidateCropDimensions(Rectangle rectangle, Bitmap bitmap)
        {
            if (rectangle.X < 0)
            {
                throw new InvalidCropDimensionsException("The X coordinate should not be outside of the image and/or less than zero");
            }
            else if (rectangle.X + width > bitmap.Width)
            {
                throw new InvalidCropDimensionsException("The X coordinate summed with the passed width is greater than the image's width.");
            }
            else if (rectangle.Y < 0)
            {
                throw new InvalidCropDimensionsException("The Y coordinate should not be outside of the image and/or less than zero");
            }
            else if (rectangle.Y + height > bitmap.Height)
            {
                throw new InvalidCropDimensionsException("The Y coordinate summed with the passed height is greater than the image's height.");
            }
            else if (rectangle.X > bitmap.Width)
            {
                throw new InvalidCropDimensionsException("The X coordinate should not be outside of the image's dimensions");
            }
            else if (rectangle.Y > bitmap.Height)
            {
                throw new InvalidCropDimensionsException("The Y coordinate should not be outside of the image's dimensions");
            }
        }
    }
}
