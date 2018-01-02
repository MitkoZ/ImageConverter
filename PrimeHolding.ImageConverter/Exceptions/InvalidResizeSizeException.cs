using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]
    public class InvalidResizeSizeException : ArgumentOutOfRangeException
    {
        internal InvalidResizeSizeException() { }
        internal InvalidResizeSizeException(string message) : base(message) { }
        internal InvalidResizeSizeException(string message, Exception inner) : base(message, inner) { }
        protected InvalidResizeSizeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
