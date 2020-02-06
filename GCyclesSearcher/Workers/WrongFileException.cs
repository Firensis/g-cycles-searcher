using System;
using System.Runtime.Serialization;

namespace GCyclesSearcher.Workers
{
    [Serializable]
    internal class WrongFileException : Exception
    {
        public WrongFileException()
        {
        }

        public WrongFileException(string message) : base(message)
        {
        }

        public WrongFileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}