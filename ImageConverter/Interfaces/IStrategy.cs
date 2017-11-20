using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Interfaces
{
    internal interface IStrategy
    {
        void Start(string srcPath, string destPath);
    }
}
