using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]
    public class InvalidPathException : GenericException
    {
        internal InvalidPathException() { }
        internal InvalidPathException(string message) : base(message) { }
        internal InvalidPathException(string message, Exception inner) : base(message, inner) { }
        protected InvalidPathException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
