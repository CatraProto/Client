using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using Serilog;
using EncryptedMessage = CatraProto.Client.Connections.Messages.EncryptedMessage;
using MessageBase = CatraProto.Client.Connections.Messages.Interfaces.MessageBase;

namespace CatraProto.Client.Connections.Loop
{
    class ReadLoop : Async.Loops.Loop
    {
        private readonly Connection _connection;
        private readonly CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private ILogger _logger;
        private MessagesHandler _messagesHandler;

        public ReadLoop(Connection connection, MessagesHandler messagesHandler, ILogger logger)
        {
            _connection = connection;
            _logger = logger.ForContext<ReadLoop>();
            _messagesHandler = messagesHandler;
        }

        private async Task Loop()
        {
            _logger.Information("Listening for incoming messages");
            var protocol = _connection.Protocol;
            while (!_cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var message = await protocol.Reader.ReadIncomingMessage(_cancellationToken.Token);
                    if (MessageBase.IsMessageEncrypted(message))
                    {
                        var encryptedMessage = new EncryptedMessage(message);

                        if (RpcReadingTools.GetRpcMessageResponseId(encryptedMessage.Message, out var messageId))
                        {
                            _messagesHandler.CompleteEncryptedMessage(encryptedMessage, messageId);
                        }
                    }
                    else
                    {
                        var plainMessage = new UnencryptedMessage(message);
                        if (!await _messagesHandler.CompleteUnencryptedMessage(plainMessage))
                        {
                            _logger.Warning("Received an unencrypted message with Id {Id} and length of {Length} bytes. The message wasn't expected, there's no task that can be completed", plainMessage.AuthKeyId, plainMessage.Length);
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Unexpected exception thrown, please report this on the github issues page");
                }
            }

            _logger.Information("ReadLoop shutdown...");
            SetLoopStopped();
        }

        protected override void StopSignal()
        {
            _logger.Information("Requesting ReadLoop shutdown");
            _cancellationToken.Cancel();
        }

        protected override Task StartSignal()
        {
            _ = Loop();
            return Task.CompletedTask;
        }
    }
}