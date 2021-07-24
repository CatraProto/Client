using System;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    public class FloodWaitError : RpcError
    {
        public override string ErrorDescription { get; }
        public TimeSpan WaitTime { get; } = new TimeSpan(-1); 
        public FloodWaitError(string errorMessage, int errorCode) : base(errorMessage, errorCode)
        {
            if (errorMessage.Length > 10 && int.TryParse(errorMessage[11..], out var waitTime))
            {
                WaitTime = TimeSpan.FromSeconds(waitTime);
                ErrorDescription = $"This error is returned whenever you call a method too many times. To use this method again, wait {waitTime} seconds";
            }
            else
            {
                ErrorDescription = $"This error is returned by the server whenever you call a method too many times. It was not possible to extract the wait time from [{errorMessage}]";
            }
        }
    }
}