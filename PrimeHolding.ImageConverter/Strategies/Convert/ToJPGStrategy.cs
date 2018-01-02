using PrimeHolding.ImageConverter.Exceptions;
using PrimeHolding.ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Strategies.Convert
{
    /// <summary>
    /// A strategy that converts an image to jpg format
    /// </summary>
    internal class ToJPGStrategy : IStrategy
    {
        /// <exception cref="InvalidPathException">Path is null or invalid</exception>
        /// <exception cref="InvalidImageFormatException">Path does not point to a supported image format</exception>
        /// <exception cref="UnathorizedAccessException">No permission to access this file/directory.</exception>
        /// <exception cref="WrongSaveImageFormatException">Image was saved with the wrong image format.</exception>
        /// <exception cref="FileNotFoundException">The file specified by <paramref name="sourcePath"/> or <paramref name="destinationPath"/> does not exist</exception>
        /// <exception cref="IOException">The file specified by <paramref name="destinationPath"/> already exists</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
        public void Start(string sourcePath, string destinationPath)
        {
            try
            {
                using (FileStream inputFileStream = new FileStream(sourcePath, FileMode.Open))
                {
                    using (FileStream outputFileStream = new FileStream(destinationPath, FileMode.CreateNew))
                    {
                        Image outputImage = Image.FromStream(inputFileStream);
                        outputImage.Save(outputFileStream, ImageFormat.Jpeg);
                    }
                }
            }
            catch (ArgumentNullException argNullEx)
            {
                throw new InvalidPathException("Path cannot be null", argNullEx);
            }
            catch (ArgumentException argEx)
            {
                if (argEx.Message == ("Parameter is not valid."))
                {
                    throw new InvalidImageFormatException("The provided path does not point to a supported image format", argEx);
                }
                else
                {
                    throw new InvalidPathException("The provided path is invalid", argEx);
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
        }
    }
}
