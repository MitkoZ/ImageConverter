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
            System.Drawing.ImageConverter imageConverter = new System.Drawing.ImageConverter();
            FileStream inputFileStream = new FileStream(sourcePath, FileMode.Open);
            Image outputImage = Image.FromStream(inputFileStream);
            FileStream outputFileStream = new FileStream(destinationPath, FileMode.CreateNew);
            outputImage.Save(outputFileStream, imageFormat);
            inputFileStream.Close();
            outputFileStream.Close();
        }
    }
}
