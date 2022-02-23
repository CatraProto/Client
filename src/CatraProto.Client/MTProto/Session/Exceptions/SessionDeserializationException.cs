using System;
using System.Drawing;

namespace CatraProto.Client.MTProto.Session.Exceptions
{
    public class SessionDeserializationException : Exception
    {
        public SessionDeserializationException(string message) : base(message)
        {
            
        }
    }
}