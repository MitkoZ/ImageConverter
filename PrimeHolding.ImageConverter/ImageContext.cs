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
        private IStrategy strategy;
        private string sourcePath;
        private string destinationPath;
        private string imageOperation;

        private int x;
        private int y;
        private int width;
        private int height;

        public ImageContext(string sourcePath, string destinationPath, string imageOperation)
        {
            this.sourcePath = sourcePath;
            this.destinationPath = destinationPath;
            this.imageOperation = imageOperation;
        }

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

        public ImageContext(string sourcePath, string destionationPath, string imageOperation, int width, int height)
        {
            this.sourcePath = sourcePath;
            this.destinationPath = destionationPath;
            this.imageOperation = imageOperation;
            this.width = width;
            this.height = height;
        }
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
