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
    internal class KeepAspectStrategy : BaseResizeStrategy, IStrategy
    {
        protected internal Size wantedSize = new Size();

        public KeepAspectStrategy(int width, int height)
        {
            ValidateWidthHeight(width, height);
            this.wantedSize.Width = width;
            this.wantedSize.Height = height;
        }

        public void Start(string sourcePath, string destinationPath)
        {
            try
            {
                Image originalImage;
                using (FileStream ifs = new FileStream(sourcePath, FileMode.Open))
                {
                    originalImage = Image.FromStream(ifs);
                }
                CalculateAspectRatio(originalImage);
                Image resizedImage = ResizeImage(originalImage, this.wantedSize);
                using (FileStream ofs = new FileStream(destinationPath, FileMode.CreateNew))
                {
                    resizedImage.Save(ofs, originalImage.RawFormat);
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

        private void CalculateAspectRatio(Image originalImage)
        {
            int sourceWidth = originalImage.Width;
            int sourceHeight = originalImage.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)wantedSize.Width / (float)sourceWidth);
            nPercentH = ((float)wantedSize.Height / (float)sourceHeight);

            nPercent = (nPercentH < nPercentW) ? nPercentH : nPercentW;

            this.wantedSize.Width = (int)(sourceWidth * nPercent);
            this.wantedSize.Height = (int)(sourceHeight * nPercent);
        }

        protected internal Image ResizeImage(Image originalImage, Size wantedSize)
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
