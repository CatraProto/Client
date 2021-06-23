using System;

namespace CatraProto.TL.Exceptions
{
	public class DeserializationException : Exception
	{
		public enum DeserializationErrors
		{
			TypeNotFound,
			ProviderReturnedNull,
			MissingParameter,
			ParameterMalformed,
			BoolTrueNull
		}

		public DeserializationException(string message, DeserializationErrors errorCode) : base(message)
		{
			ErrorCode = errorCode;
		}

		public DeserializationErrors ErrorCode { get; init; }
	}
}