using CatraProto.Client.Extensions;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Interfaces;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcMessage<T>
    {
        public IRpcError Error { get; }
        public T Response { get; }
        public bool RpcCallFailed => Error != null;

        public RpcMessage()
        {
        }

        private RpcMessage(IRpcError error, T response)
        {
            Error = error;
            Response = response;
        }

        internal static RpcMessage<T> Create(RpcError error, T response)
        {
            var rpcMessage = new RpcMessage<T>(ParseError(error), response);
            return rpcMessage;
        }

        private static IRpcError ParseError(RpcError error)
        {
            if (error == null) return null;
            switch (error)
            {
                default:
                    return new UnknownError(error.ErrorMessage, error.ErrorCode);
            }
        }

        internal bool FromBytes(byte[] message)
        {
            var ms = message.ToMemoryStream();
            using var reader = new Reader(MergedProvider.DefaultInstance, ms);
            if (reader.GetNextType() == typeof(RpcResult))
            {
                reader.Read<int>();
            }

            return false;
        }
    }
}