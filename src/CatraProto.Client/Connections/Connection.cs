using System;
using System.Threading.Tasks;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Connections.Protocols.TcpAbridged;
using Serilog;

namespace CatraProto.Client.Connections
{
    class Connection
    {
        public AsyncStateSignaler StateSignaler { get; } = new AsyncStateSignaler(true);
        public ConnectionState ConnectionState { get; set; }
        public ConnectionInfo ConnectionInfo { get; }
        public IProtocol Protocol { get; }
        private ILogger _logger;
        private ReadLoop _readLoop;
        private WriteLoop _writeLoop;
        private ConnectionProtocol _protocolType;

        public Connection(ConnectionInfo connectionInfo, ConnectionState connectionState, ConnectionProtocol protocolType, ILogger logger)
        {
            _logger = logger.ForContext<Connection>();
            ConnectionInfo = connectionInfo;
            ConnectionState = connectionState;
            _protocolType = protocolType;
            Protocol = CreateProtocol();
        }

        private IProtocol CreateProtocol()
        {
            switch (_protocolType)
            {
                case ConnectionProtocol.TcpAbridged:
                    return new Abridged(ConnectionInfo, _logger);
                default:
                    throw new NotSupportedException("Protocol not supported");
            }
        }

        public async Task ConnectAsync()
        {
            if (ConnectionState == null)
            {
                throw new Exception("A connection state must be provided before connecting");
            }
            
            while (true)
            {
                try
                {
                    _logger.Information("Connecting to {Connection}", ConnectionInfo);
                    await Protocol.ConnectAsync();
                    await StartLoops();
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error("Couldn't connect due to {Message}, trying again in 3 seconds", e.Message);
                    await Task.Delay(3000);
                }
            }


            _logger.Information("Connected to {Connection}", ConnectionInfo);
        }

        private async Task StartLoops()
        {
            _writeLoop ??= new WriteLoop(this, _logger);
            _readLoop ??= new ReadLoop(this, _logger);

            await _writeLoop.StartAsync();
            await _readLoop.StartAsync();
        }
    }
}