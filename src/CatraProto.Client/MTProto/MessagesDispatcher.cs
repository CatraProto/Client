using System;
using System.Collections.Generic;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.Extensions;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.MTProto
{
    class MessagesDispatcher
    {
        private MessagesHandler _handler;
        private ILogger _logger;

        public MessagesDispatcher(MessagesHandler messagesHandler, ILogger logger)
        {
            _logger = logger.ForContext<MessagesDispatcher>();
            _handler = messagesHandler;
        }

        public void DispatchMessage(IMessage message)
        {
            using var reader = new Reader(MergedProvider.Singleton, message.Body.ToMemoryStream());
            if (message.Body.Length == 4)
            {
                var rpcError = new RpcError
                {
                    ErrorCode = reader.Read<int>(),
                    ErrorMessage = "Error from Telegram server"
                };
                
                if (!_handler.SetMessageCompletion(0, rpcError))
                {
                    _logger.Warning($"Couldn't find a message to complete with error {rpcError.ErrorCode}");
                }

                return;
            }
            
            var nextType = reader.GetNextType();
            if (nextType == typeof(GzipPacked))
            {
                throw new NotImplementedException("Gzip stream are not implemented yet");
            }
            else if (nextType == typeof(RpcResult))
            {
                //Discarding constructor id 
                reader.Stream.Position += 4;
                var messageId = reader.Read<long>();
                if (_handler.GetMethod(messageId, out var method))
                {
                    var response = method.IsVector ? reader.ReadVector(method.Type) : reader.Read(method.Type);
                    //TODO: Database
                    _handler.SetMessageCompletion(messageId, response);
                }
                else
                {
                    _logger.Warning("Couldn't find {Id} in the list of outgoing messages", messageId);
                }
            }
            else if (nextType == typeof(MsgContainer))
            {
                throw new NotImplementedException("Containers");
            }
            else
            {
                if (_handler.GetMethod(0, out var method))
                {
                    if (nextType == typeof(IList<>) && method.IsVector || nextType == method.Type || nextType.IsSubclassOf(method.Type))
                    {
                        var response = method.IsVector ? reader.ReadVector(method.Type) : reader.Read(method.Type);
                        _handler.SetMessageCompletion(0, response);
                    }
                    else
                    {
                        //TODO
                    }
                }
            }
        }
    }
}