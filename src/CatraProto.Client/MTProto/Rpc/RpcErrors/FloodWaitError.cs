using System;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    public class FloodWaitError : RpcError
    {
        public override string ErrorDescription { get; }
        public TimeSpan WaitTime { get; }

        public FloodWaitError(string errorMessage, int errorCode, TimeSpan time) : base(errorMessage, errorCode)
        {
            WaitTime = time;
            ErrorDescription = $"This error is returned whenever you call a method too many times. To use this method again, wait {time.TotalSeconds} seconds";
        }
    }
}