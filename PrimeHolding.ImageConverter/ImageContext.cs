using System;
using PrimeHolding.ImageConverter.Interfaces;
using System.Security;
using System.IO;
using PrimeHolding.ImageConverter.Strategies.Convert;
using PrimeHolding.ImageConverter.Strategies.Resize;
using System.ComponentModel;
using PrimeHolding.ImageConverter.Exceptions;

namespace PrimeHolding.ImageConverter
{
    public class ImageContext : IContext
    {
        /// <summary>
        ///  Get or set the strategy for later execution
        /// </summary>
        private IStrategy strategy;

        /// <summary>
        ///  Get or set source file location
        /// </summary>
        private string sourcePath;

        /// <summary>
        ///  Get or set destination file location
        /// </summary>
        private string destinationPath;

        /// <summary>
        ///  Get or set the type of operation that should be done
        /// </summary>
        private string imageOperation;

        /// <summary>
        /// Get or set the x starting coordinate for the image operation
        /// </summary>
        private int x;

        /// <summary>
        /// Get or set the y starting coordinate for the image operation
        /// </summary>
        private int y;

        /// <summary>
        /// Get or set the wanted width of the output image
        /// </summary>
        private int width;

        /// <summary>
        /// Get or set the wanted height of the output image
        /// </summary>
        private int height;

        /// <summary>
        /// Creates an instance of ImageContext for converting between various image formats
        /// </summary>
        /// <param name="sourcePath">Source path of the image</param>
        /// <param name="destinationPath">Destination path of the new image</param>
        /// <param name="imageOperation">Image operation type when converting images. Valid types: ConvertToJPG, ConvertToPNG and ConvertToGIF.</param>
        public ImageContext(string sourcePath, string destinationPath, string imageOperation)
        {
            this.sourcePath = sourcePath;
            this.destinationPath = destinationPath;
            this.imageOperation = imageOperation;
        }

        /// <summary>
        /// Creates an instance of ImageContext for cropping images
        /// </summary>
        /// <param name="sourcePath">Source path of the image</param>
        /// <param name="destinationPath">Destination path of the new image</param>
        /// <param name="imageOperation">Image operation type when manipulating image size. Valid types: Crop</param>
        /// <param name="x">X starting coordinate for the image operation</param>
        /// <param name="y">Y starting coordinate for the image operation</param>
        /// <param name="width">The width of the new image</param>
        /// <param name="height">The height of the new image</param>
        public ImageContext(string sourcePath, string destionationPath, string imageOperation, int x, int y, int width, int height)
        {
            this.sourcePath = sourcePath;
            this.destinationPath = destionationPath;
            this.imageOperation = imageOperation;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Creates an instance of ImageContext for resizing images
        /// </summary>
        /// <param name="sourcePath">Source path of the image</param>
        /// <param name="destionationPath">Destination path of the new image</param>
        /// <param name="imageOperation">Image operation type when manipulating image size. Valid types: Skew, KeepAspect</param>
        /// <param name="width">The width of the new image</param>
        /// <param name="height">The height of the new image</param>
        public ImageContext(string sourcePath, string destionationPath, string imageOperation, int width, int height)
        {
            this.sourcePath = sourcePath;
            this.destinationPath = destionationPath;
            this.imageOperation = imageOperation;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// A method that executes the already set strategy
        /// </summary>
        public void ExecuteStrategy()
        {
            switch (imageOperation)
            {
                case "ConvertToPNG":
                    this.strategy = new ToPNGStrategy();
                    break;
                case "ConvertToJPG":
                    this.strategy = new ToJPGStrategy();
                    break;
                case "ConvertToGIF":
                    this.strategy = new ToGIFStrategy();
                    break;
                case "Crop":
                    this.strategy = new CropStrategy(this.x, this.y, this.width, this.height);
                    break;
                case "Skew":
                    this.strategy = new SkewStrategy(this.width, this.height);
                    break;
                case "KeepAspect":
                    this.strategy = new KeepAspectStrategy(this.width, this.height);
                    break;
                default:
                    throw new CustomInvalidEnumArgumentException("Reached default - this should not happen");
            }
            strategy.Start(this.sourcePath, this.destinationPath);
        }
    }
}
