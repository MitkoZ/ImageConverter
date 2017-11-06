using System;
using ImageConverter.Interfaces;
using System.Security;
using System.IO;
using ImageConverter.Enums;
using ImageConverter.Strategies.Convert;
using ImageConverter.Strategies.Resize;
using System.ComponentModel;

namespace ImageConverter
{
    public class ImageContext : IContext
    {
        private IStrategy strategy;
        private string sourcePath;
        private string destinationPath;
        private ImageOperation imageOperation;
        public ImageContext(Parameter parameter)
        {
            this.sourcePath = parameter.SourcePath;
            this.destinationPath = parameter.DestinationPath;
            this.imageOperation = parameter.ImageOperation;

            switch (imageOperation)
            {
                case ImageOperation.ConvertToPNG:
                    this.strategy = new ToPNGStrategy();
                    break;
                case ImageOperation.ConvertToJPG:
                    this.strategy = new ToJPGStrategy();
                    break;
                case ImageOperation.ConvertToGIF:
                    this.strategy = new ToGIFStrategy();
                    break;
                case ImageOperation.Crop:
                    this.strategy = new CropStrategy(parameter);
                    break;
                case ImageOperation.Skew:
                    this.strategy = new SkewStrategy(parameter);
                    break;
                case ImageOperation.KeepAspect:
                    this.strategy = new KeepAspectStrategy(parameter);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Reached default - this should not happen");//TODO: Custom exception
            }
        }

        public void ExecuteStrategy()
        {
            strategy.Start(this.sourcePath, this.destinationPath);
        }
    }
}
