using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter.Exceptions
{

    [Serializable]
    public class InvalidCropDimensionsException : Exception
    {
        public InvalidCropDimensionsException() { }
        public InvalidCropDimensionsException(string message) : base(message) { }
        public InvalidCropDimensionsException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCropDimensionsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
