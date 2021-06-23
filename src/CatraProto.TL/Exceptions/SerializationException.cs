using System;

namespace CatraProto.TL.Exceptions
{
	public class SerializationException : Exception
	{
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

		public SerializationErrors ErrorCode { get; init; }
	}
}