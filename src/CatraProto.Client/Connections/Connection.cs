using System;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Connections.Protocols.TcpAbridged;
using CatraProto.Client.MTProto;
using Serilog;

namespace CatraProto.Client.Connections
{
    public enum ConnectionProtocol
    {
        TcpAbridged
    }

    class Connection : IAsyncDisposable
    {
        public IProtocol Protocol { get; }
        public MessagesHandler MessagesHandler { get; }
        private Session _session;
        private ReadLoop _readLoop;
        private WriteLoop _writeLoop;
        private ILogger _logger;
        private ConnectionInfo _connectionInfo;

        private Connection(Session session, ConnectionInfo connectionInfo, ConnectionProtocol protocol = ConnectionProtocol.TcpAbridged)
        {
            _logger = session.Logger.ForContext<Connection>();
            _session = session;
            _connectionInfo = connectionInfo;
            MessagesHandler = new MessagesHandler(_session.MessageIdsHandler);
            var authkey = new AuthKey(new byte[] {1}, false);
            switch (protocol)
            {
                case ConnectionProtocol.TcpAbridged:
                    Protocol = new Abridged(connectionInfo, _logger);
                    break;
            }
        }

        public static async Task<Connection> Create(Session session, ConnectionInfo connectionInfo,
            ConnectionProtocol protocol = ConnectionProtocol.TcpAbridged)
        {
            var connection = new Connection(session, connectionInfo, protocol);
            await connection.Connect();
            await connection.StartLoops();
            return connection;
        }

        public async Task Connect()
        {
            if (Protocol.IsConnected)
            {
                _logger.Debug("Trying to connect but we are already connected");
                return;
            }

            _logger.Information("Connecting to {Connection}...", _connectionInfo);

            //For the future: it would be a great a idea to pass a cancellation token here, so that if the clients gets closed
            //before establishing a connection it will stop instead of trying again and again
            while (true)
            {
                try
                {
                    await Protocol.Connect();
                    break;
                }
                catch (Exception e)
                {
                    _logger.Debug("Error: {Message}", e.Message);
                    _logger.Error("An error occurred while connecting, trying again in 3 seconds...");
                    await Task.Delay(3000);
                }
            }

            _logger.Information("Connected to {Connection}", _connectionInfo);
        }

        private async Task StartLoops()
        {
            _writeLoop ??= new WriteLoop(this, MessagesHandler, _logger);
            _readLoop ??= new ReadLoop(this, MessagesHandler, _logger);

            await _writeLoop.Start();
            await _readLoop.Start();
        }


        public async ValueTask DisposeAsync()
        {
            if (_writeLoop != null)
            {
                await _writeLoop.Stop();
                _writeLoop.Dispose();
            }

            if (_readLoop != null)
            {
                await _readLoop.Stop();
                _readLoop.Dispose();
            }

            MessagesHandler?.Dispose();
        }
    }
}