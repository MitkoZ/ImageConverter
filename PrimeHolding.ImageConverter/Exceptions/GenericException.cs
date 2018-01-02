using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]
    public class GenericException : Exception
    {
        internal GenericException() { }
        internal GenericException(string message) : base(message) { }
        internal GenericException(string message, Exception inner) : base(message, inner) { }
        protected GenericException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
