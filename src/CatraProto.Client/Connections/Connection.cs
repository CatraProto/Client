using System;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Connections.Protocols.TcpAbridged;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using Serilog;

namespace CatraProto.Client.Connections
{
    class Connection : IDisposable
    {
        private ILogger _logger;
        private ReadLoop _readLoop;
        private Session _session;
        private WriteLoop _writeLoop;

        public Connection(Session session, ConnectionInfo connectionInfo, ConnectionProtocol protocol = ConnectionProtocol.TcpAbridged)
        {
            _logger = session.Logger.ForContext<Connection>();
            _session = session;
            MessagesHandler = new MessagesHandler(_logger);
            MessagesDispatcher = new MessagesDispatcher(MessagesHandler, _logger);
            ConnectionInfo = connectionInfo;
            switch (protocol)
            {
                case ConnectionProtocol.TcpAbridged:
                    Protocol = new Abridged(connectionInfo, _logger);
                    break;
                default:
                    throw new NotSupportedException("Protocol not supported");
            }
        }

        public MessageIdsHandler MessageIdsHandler
        {
            get => _session.MessageIdsHandler;
        }

        public MessagesDispatcher MessagesDispatcher { get; }
        public ConnectionInfo ConnectionInfo { get; }
        public MessagesHandler MessagesHandler { get; }
        public IProtocol Protocol { get; }

        public void Dispose()
        {
            MessagesHandler?.Dispose();
        }

        public async Task ConnectAsync()
        {
            if (Protocol.IsConnected)
            {
                _logger.Debug("Trying to connect but we are already connected");
                return;
            }

            _logger.Information("Connecting to {Connection}...", ConnectionInfo);

            //For the future: it would be a great to pass a cancellation token here, so that if the clients gets closed
            //before establishing a connection it will stop instead of trying again and again
            while (true)
            {
                try
                {
                    await Protocol.ConnectAsync();
                    await StartLoops();
                    break;
                }
                catch (Exception e)
                {
                    _logger.Debug("Error: {Message}", e.Message);
                    _logger.Error("An error occurred while connecting, trying again in 3 seconds...");
                    await Task.Delay(3000);
                }
            }

            _logger.Information("Connected to {Connection}", ConnectionInfo);
        }

        public Task<Task> SendObjectAsync(OutgoingMessage message, IRpcMessage rpcResponse)
        {
            return MessagesHandler.EnqueueMessage(message, rpcResponse);
        }

        private async Task StartLoops()
        {
            _writeLoop ??= new WriteLoop(this, MessagesHandler, _logger);
            _readLoop ??= new ReadLoop(this, MessagesHandler, _logger);

            await _writeLoop.StartAsync();
            await _readLoop.StartAsync();
        }
    }
}