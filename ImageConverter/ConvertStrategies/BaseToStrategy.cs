using ImageConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.ConvertStrategies
{
    public abstract class BaseToStrategy
    {
        internal void Process(string sourcePath, string destinationPath, ImageFormat imageFormat)
        {
            using (FileStream inputFileStream = new FileStream(sourcePath, FileMode.Open))
            {
                using (FileStream outputFileStream = new FileStream(destinationPath, FileMode.CreateNew))
                {
                    System.Drawing.ImageConverter imageConverter = new System.Drawing.ImageConverter();
                    Image outputImage = Image.FromStream(inputFileStream);
                    outputImage.Save(outputFileStream, imageFormat);
                }
            }

        }
    }
}
