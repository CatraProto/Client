/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.IO;
using CatraProto.Client.Connections.MessageScheduling.Trackers;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;
using CatraProto.TL.Results;
using Serilog;

namespace CatraProto.Client.MTProto.Deserializers
{
    internal class RpcDeserializer : IObjectParser
    {
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
            if (_messageCompletionTracker.GetRpcMethod(rpcObject.ReqMsgId, out var method, out _))
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
                    if (constructorId == MergedProvider.Singleton.VectorId)
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
                var currentPosition = reader.Stream.Position;
                if (currentPosition - 12 > 0)
                {
                    return new ReadResult<IObject>("Failed to parse rpc message because the message id could not be found", ParserErrors.ExternalError);
                }
                else
                {
                    rpcObject.Result = new MessageFailed();
                }
            }

            return new ReadResult<IObject>(obj);
        }
    }
}