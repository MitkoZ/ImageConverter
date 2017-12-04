using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Interfaces
{
    /// <summary>
    /// An interface that each strategy should implement
    /// </summary>
    internal interface IStrategy
    {
        /// <summary>
        /// The start point of every strategy (only for inner use - in the context)
        /// </summary>
        /// <param name="srcPath">The source path of the image to convert</param>
        /// <param name="destPath">The destination path of the new converted image</param>
        void Start(string srcPath, string destPath);
    }
}
