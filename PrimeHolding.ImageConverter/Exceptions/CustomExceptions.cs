using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.ImageConverter.Exceptions
{
    [Serializable]//TODO: change to public and each exception in separate file
    public class CustomBaseException : Exception
    {
        public CustomBaseException() { }
        public CustomBaseException(string message) : base(message) { }
        public CustomBaseException(string message, Exception inner) : base(message, inner) { }
        protected CustomBaseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class InvalidCropDimensionsException : ArgumentOutOfRangeException
    {
        public InvalidCropDimensionsException() { }
        public InvalidCropDimensionsException(string message) : base(message) { }
        public InvalidCropDimensionsException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCropDimensionsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomArgumentException : ArgumentException
    {
        public CustomArgumentException() { }
        public CustomArgumentException(string message) : base(message) { }
        public CustomArgumentException(string message, Exception inner) : base(message, inner) { }
        protected CustomArgumentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomArgumentNullException : ArgumentNullException
    {
        public CustomArgumentNullException() { }
        public CustomArgumentNullException(string message) : base(message) { }
        public CustomArgumentNullException(string message, Exception inner) : base(message, inner) { }
        protected CustomArgumentNullException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomArgumentOutOfRangeException : ArgumentOutOfRangeException
    {
        public CustomArgumentOutOfRangeException() { }
        public CustomArgumentOutOfRangeException(string message) : base(message) { }
        public CustomArgumentOutOfRangeException(string message, Exception inner) : base(message, inner) { }
        protected CustomArgumentOutOfRangeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomNotSupportedException : NotSupportedException
    {
        public CustomNotSupportedException() { }
        public CustomNotSupportedException(string message) : base(message) { }
        public CustomNotSupportedException(string message, Exception inner) : base(message, inner) { }
        protected CustomNotSupportedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomSecurityException : SecurityException
    {
        public CustomSecurityException() { }
        public CustomSecurityException(string message) : base(message) { }
        public CustomSecurityException(string message, Exception inner) : base(message, inner) { }
        protected CustomSecurityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomFileNotFoundException : FileNotFoundException
    {
        public CustomFileNotFoundException() { }
        public CustomFileNotFoundException(string message) : base(message) { }
        public CustomFileNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected CustomFileNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomDirectoryNotFoundException : DirectoryNotFoundException
    {
        public CustomDirectoryNotFoundException() { }
        public CustomDirectoryNotFoundException(string message) : base(message) { }
        public CustomDirectoryNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected CustomDirectoryNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomPathTooLongException : PathTooLongException
    {
        public CustomPathTooLongException() { }
        public CustomPathTooLongException(string message) : base(message) { }
        public CustomPathTooLongException(string message, Exception inner) : base(message, inner) { }
        protected CustomPathTooLongException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomIOException : IOException
    {
        public CustomIOException() { }
        public CustomIOException(string message) : base(message) { }
        public CustomIOException(string message, Exception inner) : base(message, inner) { }
        protected CustomIOException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomExternalException : ExternalException
    {
        public CustomExternalException() { }
        public CustomExternalException(string message) : base(message) { }
        public CustomExternalException(string message, Exception inner) : base(message, inner) { }
        protected CustomExternalException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomOutOfMemoryException : OutOfMemoryException
    {
        public CustomOutOfMemoryException() { }
        public CustomOutOfMemoryException(string message) : base(message) { }
        public CustomOutOfMemoryException(string message, Exception inner) : base(message, inner) { }
        protected CustomOutOfMemoryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CustomInvalidEnumArgumentException : InvalidEnumArgumentException
    {
        public CustomInvalidEnumArgumentException() { }
        public CustomInvalidEnumArgumentException(string message) : base(message) { }
        public CustomInvalidEnumArgumentException(string message, Exception inner) : base(message, inner) { }
        protected CustomInvalidEnumArgumentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
