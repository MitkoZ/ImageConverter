using System;
using ImageConverter.Interfaces;
using System.Security;
using System.IO;

namespace ImageConverter
{
    public class ImageContext : IContext
    {
        public IStrategy Strategy { get; internal set; }
        public string SourcePath { get; internal set; }
        public string DestinationPath { get; internal set; }
        public string Type { get; internal set; }
        public ImageContext(IStrategy strategy, string sourcePath, string destinationPath, string type)
        {
            this.Strategy = strategy;
            this.SourcePath = sourcePath;
            this.DestinationPath = destinationPath;
            this.Type = type;
        }

        public void ExecuteStrategy()
        {
            Strategy.Start(this.SourcePath, this.DestinationPath);
        }
    }
}
