using System;

namespace CatraProto.Client.Async.Signalers.Exceptions
{
    public class UninitializedException : Exception
    {
        public UninitializedException() : base("No state has been signaled yet")
        {

        }
    }
}