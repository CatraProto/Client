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
		
		public DeserializationErrors ErrorCode { get; init; }

		public DeserializationException(string message, DeserializationErrors errorCode) : base(message)
		{
			ErrorCode = errorCode;
		}
	}
}