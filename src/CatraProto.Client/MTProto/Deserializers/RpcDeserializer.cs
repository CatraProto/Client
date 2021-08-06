using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Trackers;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
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
        
        public bool DeserializeObject(IObject obj, Reader reader)
        {
            if (obj is RpcObject rpcObject)
            {
                rpcObject.MessageId = reader.Read<long>();
                if (_messageCompletionTracker.GetRpcMethod(rpcObject.MessageId, out var method))
                {
                    var toDispose = false;
                    var nextType = reader.GetNextType();
                    if (nextType == typeof(GzipPacked))
                    {
                        _logger.Information("Result of rpc query is wrapped by a gzip packet");
                        reader = new Reader(MergedProvider.Singleton, GzipHandler.ReadGzipPacket(reader.Read<GzipPacked>().PackedData));
                        toDispose = true;
                    }

                    rpcObject.Response = method!.IsVector ? reader.ReadVector(method.Type) : reader.Read(method.Type);

                    if (toDispose)
                    {
                        reader.Dispose();
                    }
                    return true;
                }
            }

            return false;
        }
    }
}