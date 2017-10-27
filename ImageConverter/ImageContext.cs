using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter
{
    public class ImageContext : IContext
    {
        public IStrategy Strategy { get; set; }
        public string SourcePath { get; }
        public string DestinationPath { get; }
        public string Type { get; set; }
        public ImageContext(IStrategy strategy, string sourcePath, string destinationPath, string type)
        {
            this.Strategy = strategy;
            this.SourcePath = sourcePath;
            this.DestinationPath = destinationPath;
        }

        public void ExecuteStrategy()
        {
            Strategy.Process();
        }
    }
}
