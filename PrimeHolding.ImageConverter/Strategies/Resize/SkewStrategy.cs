using PrimeHolding.ImageConverter.Exceptions;
using PrimeHolding.ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Strategies.Resize
{
    /// <summary>
    /// A strategy that resizes an image to the given width and height without keeping the old image's proportions
    /// </summary>
    internal class SkewStrategy : BaseResizeStrategy, IStrategy
    {
        /// <summary>
        /// Get or set the new size of the image
        /// </summary>
        protected internal Size wantedSize = new Size();

        /// <summary>
        /// Setting the wanted width and height of the new image
        /// </summary>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <exception cref="InvalidResizeSizeException">The image's new width or height is invalid. (below 0)</exception>
        public SkewStrategy(int width, int height)
        {
            ValidateWidthHeight(width, height);
            this.wantedSize.Width = width;
            this.wantedSize.Height = height;
        }

        /// <exception cref="InvalidResizeSizeException">The image's new width or height is invalid. (below 0)</exception>
        /// <exception cref="InvalidPathException">Path is null or invalid</exception>
        /// <exception cref="InvalidImageFormatException">Path does not point to a supported image format</exception>
        /// <exception cref="UnathorizedAccessException">No permission to access this file/directory.</exception>
        /// <exception cref="WrongSaveImageFormatException">Image was saved with the wrong image format.</exception>
        /// <exception cref="GenericException">Initializing a new instance of the Bitmap class failed, or image has an indexed pixel format or its format is undefined</exception>
        /// <exception cref="FileNotFoundException">The file specified by <paramref name="sourcePath"/> or <paramref name="destinationPath"/> does not exist</exception>
        /// <exception cref="IOException">The file specified by <paramref name="destinationPath"/> already exists</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        public void Start(string sourcePath, string destinationPath)
        {
            try
            {
                using (FileStream ifs = new FileStream(sourcePath, FileMode.Open))
                {
                    Image originalImage = Image.FromStream(ifs);
                    Image resizedImage = ResizeImage(originalImage, this.wantedSize);
                    using (FileStream ofs = new FileStream(destinationPath, FileMode.CreateNew))
                    {
                        resizedImage.Save(ofs, originalImage.RawFormat);
                    }
                }
            }
            catch (ArgumentNullException argNullEx)
            {
                throw new InvalidPathException(argNullEx.Message, argNullEx);
            }
            catch (ArgumentException argEx)
            {
                if (argEx.Message == "Parameter is not valid.")
                {
                    throw new InvalidImageFormatException("The provided path does not point to a supported image format", argEx);
                }
                else
                {
                    throw new InvalidPathException(argEx.Message, argEx);
                }
            }
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
            catch (Exception ex)
            {
                throw new GenericException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Resizes the image
        /// </summary>
        /// <param name="originalImage">The source image that should be resized</param>
        /// <param name="wantedSize">The size that the new image should be</param>
        /// <returns>The resized image</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        private Image ResizeImage(Image originalImage, Size wantedSize)
        {
            Bitmap bitmap = new Bitmap(wantedSize.Width, wantedSize.Height);
            Graphics graphic = Graphics.FromImage((Image)bitmap);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(originalImage, 0, 0, wantedSize.Width, wantedSize.Height);
            graphic.Dispose();
            return (Image)bitmap;
        }
    }
}
