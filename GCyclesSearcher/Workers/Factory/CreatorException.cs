using System;
using System.Runtime.Serialization;

namespace GCyclesSearcher.Workers.Factory
{
    [Serializable]
    internal class GraphFactoryException : Exception
    {
        public GraphFactoryException()
        {
        }

        public GraphFactoryException(string message) : base(message)
        {
        }

        public GraphFactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GraphFactoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}