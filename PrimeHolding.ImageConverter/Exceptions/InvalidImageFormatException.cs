using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]
    public class InvalidImageFormatException : ArgumentException
    {
        internal InvalidImageFormatException() { }
        internal InvalidImageFormatException(string message) : base(message) { }
        internal InvalidImageFormatException(string message, Exception inner) : base(message, inner) { }
        protected InvalidImageFormatException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
