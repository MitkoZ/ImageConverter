using ImageConverter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter
{
    public class Parameter
    {
        internal string SourcePath { get; set; }
        internal string DestinationPath { get; set; }
        internal ImageOperation ImageOperation { get; set; }
        internal int X { get; set; }
        internal int Y { get; set; }
        internal int Width { get; set; }
        internal int Height { get; set; }
        public Parameter(string sourcePath, string destionationPath, ImageOperation imageOperation)
        {
            this.SourcePath = sourcePath;
            this.DestinationPath = destionationPath;
            this.ImageOperation = imageOperation;
        }

        public Parameter(string sourcePath, string destionationPath, ImageOperation imageOperation, int x, int y, int width, int height)
        {
            this.SourcePath = sourcePath;
            this.DestinationPath = destionationPath;
            this.ImageOperation = imageOperation;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public Parameter(string sourcePath, string destionationPath, ImageOperation imageOperation, int width, int height)
        {
            this.SourcePath = sourcePath;
            this.DestinationPath = destionationPath;
            this.ImageOperation = imageOperation;
            this.Width = width;
            this.Height = height;
        }
    }
}
