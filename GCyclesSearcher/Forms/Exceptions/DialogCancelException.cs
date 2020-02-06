using System;
using System.Runtime.Serialization;

namespace GCyclesSearcher.Forms.Exceptions
{
    [Serializable]
    internal class DialogCancelException : Exception
    {
        public DialogCancelException()
        {
        }

        public DialogCancelException(string message) : base(message)
        {
        }

        public DialogCancelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DialogCancelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}