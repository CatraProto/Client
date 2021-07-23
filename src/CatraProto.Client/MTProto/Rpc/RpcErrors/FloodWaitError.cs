using System;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    public class FloodWaitError : IRpcError
    {
        public int ErrorCode { get; }
        public string ErrorMessage { get; }
        public string ErrorDescription { get; }
        public TimeSpan WaitTime { get; } = new TimeSpan(-1); 
        public FloodWaitError(string errorMessage, int errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
            var number = ErrorMessage[11..];
            if (int.TryParse(number, out var waitTime))
            {
                WaitTime = TimeSpan.FromSeconds(waitTime);
                ErrorDescription = $"This error is returned whenever you call a method too many times, to use this method again, wait {waitTime} seconds";
            }
        }
    }
}