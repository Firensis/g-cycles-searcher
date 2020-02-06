using System;
using System.Runtime.Serialization;

namespace GCyclesSearcher.Forms.Exceptions
{
    [Serializable]
    internal class WrongCycleTypeException : Exception
    {
        public WrongCycleTypeException()
        {
        }

        public WrongCycleTypeException(string message) : base(message)
        {
        }

        public WrongCycleTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongCycleTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}