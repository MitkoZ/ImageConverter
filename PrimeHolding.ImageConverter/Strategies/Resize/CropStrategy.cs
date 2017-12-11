using PrimeHolding.ImageConverter.Interfaces;
using System.Drawing;
using System.IO;
using System;
using PrimeHolding.ImageConverter.Exceptions;

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

        public void Start(string srcPath, string destPath)
        {
            try
            {
                using (FileStream ifs = new FileStream(srcPath, FileMode.Open))
                {
                    Bitmap bitmap = new Bitmap(ifs);
                    Rectangle rectangle = new Rectangle(this.x, this.y, this.width, this.height);
                    ValidateCropDimensions(rectangle, bitmap);
                    Bitmap croppedBitmap = bitmap.Clone(rectangle, bitmap.PixelFormat);
                    using (FileStream ofs = new FileStream(destPath, FileMode.CreateNew))
                    {
                        croppedBitmap.Save(ofs, bitmap.RawFormat);
                    }
                }
            }
            catch (ArgumentNullException argNullEx)
            {
                throw new CustomArgumentNullException(argNullEx.Message, argNullEx);
            }
            catch (ArgumentOutOfRangeException argOutOfRangeEx)
            {
                throw new CustomArgumentOutOfRangeException(argOutOfRangeEx.Message, argOutOfRangeEx);
            }
            catch (ArgumentException argEx)
            {
                throw new CustomArgumentException(argEx.Message, argEx);
            }
            catch (NotSupportedException notSuppEx)
            {
                throw new CustomNotSupportedException(notSuppEx.Message, notSuppEx);
            }
            catch (System.Security.SecurityException securityEx)
            {
                throw new CustomSecurityException(securityEx.Message, securityEx);
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                throw new CustomFileNotFoundException(fileNotFoundEx.Message, fileNotFoundEx);
            }
            catch (DirectoryNotFoundException directoryNotFoundEx)
            {
                throw new CustomDirectoryNotFoundException(directoryNotFoundEx.Message, directoryNotFoundEx);
            }
            catch (PathTooLongException pathTooLongEx)
            {
                throw new CustomPathTooLongException(pathTooLongEx.Message, pathTooLongEx);
            }
            catch (IOException ioEx)
            {
                throw new CustomIOException(ioEx.Message, ioEx);
            }
            catch (System.Runtime.InteropServices.ExternalException externalEx)
            {
                throw new CustomExternalException(externalEx.Message, externalEx);
            }
            catch (OutOfMemoryException outOfMemoryEx)
            {
                throw new CustomOutOfMemoryException(outOfMemoryEx.Message, outOfMemoryEx);
            }
            catch (Exception ex)
            {
                throw new CustomBaseException(ex.Message, ex);
            }

        }

        /// <summary>
        /// Validation of the user's input parameters
        /// </summary>
        /// <param name="rectangle">User's input container</param>
        /// <param name="bitmap">Source image container</param>
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
