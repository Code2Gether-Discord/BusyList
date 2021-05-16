using System;
using System.Runtime.Serialization;

namespace BusyList.Commands
{
    [Serializable]
    internal class UnregisteredCommandException : Exception
    {
        public UnregisteredCommandException()
        {
        }

        public UnregisteredCommandException(string message) : base(message)
        {
        }

        public UnregisteredCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnregisteredCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}