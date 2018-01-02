using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]
    public class InvalidPixelFormatException : GenericException
    {
        internal InvalidPixelFormatException() { }
        internal InvalidPixelFormatException(string message) : base(message) { }
        internal InvalidPixelFormatException(string message, Exception inner) : base(message, inner) { }
        protected InvalidPixelFormatException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
