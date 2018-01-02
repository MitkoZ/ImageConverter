using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]
    public class WrongSaveImageFormatException : ExternalException
    {
        internal WrongSaveImageFormatException() { }
        internal WrongSaveImageFormatException(string message) : base(message) { }
        internal WrongSaveImageFormatException(string message, Exception inner) : base(message, inner) { }
        protected WrongSaveImageFormatException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
