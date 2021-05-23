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

    class Connection : IDisposable
    {
        public IProtocol Protocol { get; }
        public MessagesHandler MessagesHandler { get; }
        private ConnectionInfo _connectionInfo;
        private ILogger _logger;
        private ReadLoop _readLoop;
        private Session _session;
        private WriteLoop _writeLoop;

        public Connection(Session session, ConnectionInfo connectionInfo, ConnectionProtocol protocol = ConnectionProtocol.TcpAbridged)
        {
            _logger = session.Logger.ForContext<Connection>();
            _session = session;
            _connectionInfo = connectionInfo;
            MessagesHandler = new MessagesHandler(_logger);
            var authkey = new AuthKey(new byte[] {1}, false);
            switch (protocol)
            {
                case ConnectionProtocol.TcpAbridged:
                    Protocol = new Abridged(connectionInfo, _logger);
                    break;
            }
        }

        public async Task Connect()
        {
            if (Protocol.IsConnected)
            {
                _logger.Debug("Trying to connect but we are already connected");
                return;
            }

            _logger.Information("Connecting to {Connection}...", _connectionInfo);

            //For the future: it would be a great to pass a cancellation token here, so that if the clients gets closed
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
        
        
        public void Dispose()
        {
            MessagesHandler?.Dispose();
        }
    }
}