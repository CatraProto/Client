using System;

namespace CatraProto.Client.Async.Loops.Exceptions
{
    public class LoopUngracefullyExited : Exception
    {
        public LoopUngracefullyExited() : base("Loop exited without setting state")
        {

        }
    }
}