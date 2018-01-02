using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]
    public class InvalidImageOperation : GenericException
    {
        internal InvalidImageOperation() { }
        internal InvalidImageOperation(string message) : base(message) { }
        internal InvalidImageOperation(string message, Exception inner) : base(message, inner) { }
        protected InvalidImageOperation(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
