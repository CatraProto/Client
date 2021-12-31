using System.IO;
using System.Linq;
using CatraProto.Client.Connections.MessageScheduling.Trackers;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;
using Serilog;

namespace CatraProto.Client.MTProto.Deserializers
{
    class RpcDeserializer : ICustomObjectDeserializer
    {
        private readonly MessageCompletionTracker _messageCompletionTracker;
        private readonly ILogger _logger;

        public RpcDeserializer(MessageCompletionTracker messageCompletionTracker, ILogger logger)
        {
            _messageCompletionTracker = messageCompletionTracker;
            _logger = logger.ForContext<RpcDeserializer>();
        }

        public void DeserializeObject(IObject obj, Reader reader)
        {
            if (obj is not RpcObject rpcObject)
            {
                return;
            }

            rpcObject.MessageId = reader.Read<long>();
            if (!_messageCompletionTracker.GetRpcMethod(rpcObject.MessageId, out var method))
            {
                throw new DeserializationException($"Couldn't find RPC message {rpcObject.MessageId}", DeserializationException.DeserializationErrors.ProviderReturnedNull);
            }
            
            rpcObject.Response = method!.IsVector ? reader.ReadVector(method.Type) : reader.Read(method.Type);
        }
    }
}