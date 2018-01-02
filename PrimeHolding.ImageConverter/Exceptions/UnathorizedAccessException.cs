using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]
    public class UnathorizedAccessException : SecurityException
    {
        internal UnathorizedAccessException() { }
        internal UnathorizedAccessException(string message) : base(message) { }
        internal UnathorizedAccessException(string message, Exception inner) : base(message, inner) { }
        protected UnathorizedAccessException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
