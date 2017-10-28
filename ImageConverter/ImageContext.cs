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
        private IStrategy strategy;
        private string sourcePath;
        private string destinationPath;
        private string type;
        public ImageContext(IStrategy strategy, string sourcePath, string destinationPath, string type)
        {
            this.strategy = strategy;
            this.sourcePath = sourcePath;
            this.destinationPath = destinationPath;
            this.type = type;
        }

        public void ExecuteStrategy()
        {
            strategy.Process(sourcePath, destinationPath);
        }
    }
}
