using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]
    public class InvalidCropDimensionsException : GenericException
    {
        internal InvalidCropDimensionsException() { }
        internal InvalidCropDimensionsException(string message) : base(message) { }
        internal InvalidCropDimensionsException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCropDimensionsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
