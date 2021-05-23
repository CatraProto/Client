﻿using System;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class WriteLoop : Async.Loops.Loop
    {
        private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private Connection _connection;
        private ILogger _logger;
        private MessagesHandler _messagesHandler;

        public WriteLoop(Connection connection, MessagesHandler messagesHandler, ILogger logger)
        {
            _connection = connection;
            _messagesHandler = messagesHandler;
            _logger = logger.ForContext<WriteLoop>();
        }

        private async Task UnencryptedLoop()
        {
            _logger.Information("Listening for outgoing messages...");
            while (!_cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // var message = await _messagesHandler.ListenOutgoingUnencrypted(_cancellationToken.Token);
                    // _logger.Information("Sending message with Id {Id} as unencryptedMessage, length {Length}", message.MessageId /*, message.Length*/);
                    // await _connection.Protocol.Writer.SendMessage(message.Export());
                }
                catch (OperationCanceledException)
                {
                    //Ignored: Cancellation token.
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Unexpected exception thrown, please report this on the github issues page");
                }
            }

            _logger.Information("WriteLoop shut down");
            SetLoopStopped();
        }

        protected override void StopSignal()
        {
            _cancellationToken.Cancel();
        }

        protected override Task StartSignal()
        {
            _ = UnencryptedLoop();
            return Task.CompletedTask;
        }
    }
}