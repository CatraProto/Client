using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Extensions;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class ReadLoop : Async.Loops.Loop
    {
        private readonly CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private readonly Connection _connection;
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
                    var reader = new Reader(MergedProvider.Singleton, message.ToMemoryStream());
                    var authKey = reader.Read<long>();

                    if (reader.GetNextType() == typeof(RpcResult))
                    {
                        var response = new RpcReader
                        {
                            MessageId = reader.Read<long>()
                        };
                        
                        if (_messagesHandler.GetMessageMethod(response.MessageId, out var method))
                        {
                            response.ReadObject(method, reader);
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Unexpected exception thrown, please report this on the github issues page");
                }
            }

            _logger.Information("ReadLoop shutdown");
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