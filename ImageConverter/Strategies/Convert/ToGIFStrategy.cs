using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageConverter.Strategies.Convert
{
    internal class ToGIFStrategy : IStrategy
    {
        public void Start(string sourcePath, string destinationPath)
        {
            using (FileStream inputFileStream = new FileStream(sourcePath, FileMode.Open))
            {
                using (FileStream outputFileStream = new FileStream(destinationPath, FileMode.CreateNew))
                {
                    Image outputImage = Image.FromStream(inputFileStream);
                    outputImage.Save(outputFileStream, ImageFormat.Gif);
                }
            }
        }
    }
}
