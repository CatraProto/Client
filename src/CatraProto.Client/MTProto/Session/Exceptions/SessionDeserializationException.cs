using System;

namespace CatraProto.Client.MTProto.Session.Exceptions
{
    public class SessionDeserializationException : Exception
    {
        public SessionDeserializationException(string message) : base(message)
        {

        }
    }
}