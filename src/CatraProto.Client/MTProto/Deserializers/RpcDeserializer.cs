using System.IO;
using System.Linq;
using CatraProto.Client.Connections.MessageScheduling.Trackers;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Parsers;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;
using CatraProto.TL.Results;
using Serilog;

namespace CatraProto.Client.MTProto.Deserializers
{
    class RpcDeserializer : IObjectParser
    {
        private static readonly MissingRequestError MissingRequestError = new MissingRequestError();
        private readonly MessageCompletionTracker _messageCompletionTracker;
        private readonly ILogger _logger;

        public RpcDeserializer(MessageCompletionTracker messageCompletionTracker, ILogger logger)
        {
            _messageCompletionTracker = messageCompletionTracker;
            _logger = logger.ForContext<RpcDeserializer>();
        }

        public bool CanReadObject(IObject obj)
        {
            return obj is RpcResult;
        }

        public ReadResult<IObject> ReadObject(IObject obj, Reader reader)
        {
            var rpcObject = (RpcResult)obj;
            var tryGetId = reader.CheckLength<IObject>(8);
            if (tryGetId.IsError)
            {
                return tryGetId;
            }

            rpcObject.ReqMsgId = reader.ReadInt64().Value;
            if (_messageCompletionTracker.GetRpcMethod(rpcObject.ReqMsgId, out var method))
            {
                var constructorId = reader.ReadInt32().Value;
                reader.Stream.Seek(-4, SeekOrigin.Current);
                if (constructorId == RpcError.ConstructorId)
                {
                    var tryParseObject = reader.ReadObject<IObject>();
                    if (tryParseObject.IsError)
                    {
                        return tryParseObject;
                    }

                    var error = (RpcError)tryParseObject.Value;
                    rpcObject.Result = ParsersList.GetError(error);
                }
                else
                {
                    if(constructorId == MergedProvider.Singleton.VectorId)
                    {
                        var getVector = reader.ReadVector<object>(method.Type);
                        if (getVector.IsError)
                        {
                            return ReadResult<IObject>.Move(getVector);
                        }
                        rpcObject.Result = getVector.Value;
                    }
                    else
                    {
                        var getResult = reader.Read(method.Type);
                        if (getResult.IsError)
                        {
                            return ReadResult<IObject>.Move(getResult);
                        }
                        rpcObject.Result = getResult.Value;
                    }
                }
            }
            else
            {
                _logger.Information("Could not find {MessageId} in the list of outgoing rpc requests", rpcObject.ReqMsgId);
                rpcObject.Result = MissingRequestError;
            }

            return new ReadResult<IObject>(obj);
        }
    }
}