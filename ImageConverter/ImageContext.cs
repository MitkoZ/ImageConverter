using System;
using ImageConverter.Interfaces;
using System.Security;
using System.IO;

namespace ImageConverter
{
    public class ImageContext : IContext
    {
        internal IStrategy Strategy { get; set; }
        internal string SourcePath { get; set; }
        internal string DestinationPath { get; set; }
        internal string Type { get; set; }
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
