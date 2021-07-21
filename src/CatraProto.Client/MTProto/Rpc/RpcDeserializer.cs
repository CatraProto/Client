using CatraProto.Client.Connections;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;
using Serilog;

namespace CatraProto.Client.MTProto.Rpc
{
    class RpcDeserializer : ICustomObjectDeserializer
    {
        private MessagesHandler _messagesHandler;
        private ILogger _logger;

        public RpcDeserializer(MessagesHandler messagesHandler, ILogger logger)
        {
            _messagesHandler = messagesHandler;
            _logger = logger.ForContext<RpcDeserializer>();
        }
        
        public bool DeserializeObject(IObject obj, Reader reader)
        {
            if (obj is RpcObject rpcObject)
            {
                rpcObject.MessageId = reader.Read<long>();
                if (_messagesHandler.GetMethod(rpcObject.MessageId, out var method))
                {
                    var toDispose = false;
                    var nextType = reader.GetNextType();
                    if (nextType == typeof(GzipPacked))
                    {
                        _logger.Information("Result of rpc query is wrapped by a gzip packet");
                        reader = new Reader(MergedProvider.Singleton, GzipHandler.ReadGzipPacket(reader.Read<GzipPacked>().PackedData));
                        toDispose = true;
                    }

                    if (method.IsVector)
                    {
                        rpcObject.Response = reader.ReadVector(method.Type);
                    }
                    else
                    {
                        rpcObject.Response = reader.Read(method.Type);
                    }

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