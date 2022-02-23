using System;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcException : Exception
    {
        public RpcError RpcError { get; }

        public RpcException(RpcError rpcError) : base(rpcError.ToString())
        {
            RpcError = rpcError;
        }
    }
}