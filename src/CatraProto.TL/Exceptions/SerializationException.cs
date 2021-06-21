using System;

namespace CatraProto.TL.Exceptions
{
    public class SerializationException : Exception
    {
        public SerializationErrors ErrorCode { get; init; }

        public enum SerializationErrors
        {
            BoolNull,
            TypeNotFound,
            BitSizeMismatch
        }

        public SerializationException(string message, SerializationErrors errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}