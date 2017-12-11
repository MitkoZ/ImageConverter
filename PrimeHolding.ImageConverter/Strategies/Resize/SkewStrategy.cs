using PrimeHolding.ImageConverter.Exceptions;
using PrimeHolding.ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
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
        public SkewStrategy(int width, int height)
        {
            try
            {
                ValidateWidthHeight(width, height);
            }
            catch (ArgumentOutOfRangeException argOutOfRangeException)
            {
                throw new CustomArgumentOutOfRangeException(argOutOfRangeException.Message, argOutOfRangeException);
            }
            catch (Exception ex)
            {
                throw new CustomBaseException(ex.Message, ex);
            }
            this.wantedSize.Width = width;
            this.wantedSize.Height = height;
        }

        public void Start(string srcPath, string destPath)
        {
            try
            {
                using (FileStream ifs = new FileStream(srcPath, FileMode.Open))
                {
                    Image originalImage = Image.FromStream(ifs);
                    Image resizedImage = ResizeImage(originalImage, this.wantedSize);
                    using (FileStream ofs = new FileStream(destPath, FileMode.CreateNew))
                    {
                        resizedImage.Save(ofs, originalImage.RawFormat);
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
            catch (Exception ex)
            {
                throw new CustomBaseException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Resizes the image
        /// </summary>
        /// <param name="originalImage">The source image that should be resized</param>
        /// <param name="wantedSize">The size that the new image should be</param>
        /// <returns>The resized image</returns>
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
