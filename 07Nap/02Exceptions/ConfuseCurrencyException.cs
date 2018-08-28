using System;
using System.Runtime.Serialization;

namespace _02Exceptions
{
    [Serializable]
    public class ConfuseCurrencyException : AccountException
    {
        public ConfuseCurrencyException()
        {
        }

        public ConfuseCurrencyException(string message) : base(message)
        {
        }

        public ConfuseCurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConfuseCurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}