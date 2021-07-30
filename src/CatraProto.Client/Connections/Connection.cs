using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Connections.Protocols.TcpAbridged;
using Serilog;

namespace CatraProto.Client.Connections
{
    class Connection : IAsyncDisposable
    {
        public AsyncSignaler Signaler { get; } = new AsyncSignaler(true);
        public ConnectionState ConnectionState { get; set; }
        public ConnectionInfo ConnectionInfo { get; }
        public IProtocol Protocol { get; private set; }
        private SingleCallAsync<CancellationToken> _singleCallAsync;
        private ConnectionProtocol _protocolType;
        private WriteLoop _writeLoop;
        private ReadLoop _readLoop;
        private ILogger _logger;

        public Connection(ConnectionInfo connectionInfo, ConnectionState connectionState, ConnectionProtocol protocolType, ILogger logger)
        {
            _logger = logger.ForContext<Connection>();
            ConnectionInfo = connectionInfo;
            ConnectionState = connectionState;
            _singleCallAsync = new SingleCallAsync<CancellationToken>(InternalConnectAsync);
            _protocolType = protocolType;
        }
        
        public Task ConnectAsync(CancellationToken token = default)
        {
            return _singleCallAsync.GetCall(token);
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

        private async Task InternalConnectAsync(CancellationToken token)
        {
            if (_writeLoop != null)
            {
                await _writeLoop.StopAsync();
            }

            if (_readLoop != null)
            {
                await _readLoop.StopAsync();
            }

            if (Protocol != null)
            {
                await Protocol.CloseAsync();
            }

            Protocol = CreateProtocol();
            while (true)
            {
                try
                {
                    _logger.Information("Connecting to {Connection}", ConnectionInfo);
                    await Protocol.ConnectAsync(token);
                    await StartLoops();
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error("Couldn't connect due to {Message}, trying again in 3 seconds", e.Message);
                    await Task.Delay(3000, token);
                }
            }
            _logger.Information("Successfully connected to {Connection}", ConnectionInfo);
        }

        private async Task StartLoops()
        {
            _writeLoop ??= new WriteLoop(this, _logger);
            _readLoop ??= new ReadLoop(this, _logger);

            await _writeLoop.StartAsync();
            await _readLoop.StartAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_writeLoop != null)
            {
                await _writeLoop.StopAsync();
            }

            if (_readLoop != null)
            {
                await _readLoop.StopAsync();
            }

            Signaler.Dispose();
        }
    }
}