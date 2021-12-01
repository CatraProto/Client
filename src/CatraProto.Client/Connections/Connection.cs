using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Connections.Protocols.TcpAbridged;
using CatraProto.Client.MTProto.Session;
using Serilog;

namespace CatraProto.Client.Connections
{
    class Connection : IAsyncDisposable
    {
        public AsyncSignaler Signaler { get; } = new AsyncSignaler(true);
        public MTProtoState MtProtoState { get; }
        public MessagesHandler MessagesHandler { get; }
        public MessagesDispatcher MessagesDispatcher { get; }
        public ConnectionInfo ConnectionInfo { get; }
        public IProtocol? Protocol { get; private set; }

        private readonly SingleCallAsync<CancellationToken> _singleCallAsync;
        private readonly ConnectionProtocol _protocolType;
        private SendLoopController? _writeLoop;
        private ReceiveLoopController? _readLoop;
        private PingLoopController? _pingLoop;
        private readonly ILogger _logger;

        public Connection(ConnectionInfo connectionInfo, ClientSession clientSession)
        {
            _logger = clientSession.Logger.ForContext<Connection>();
            ConnectionInfo = connectionInfo;
            MessagesHandler = new MessagesHandler(clientSession.Logger);
            MtProtoState = new MTProtoState(connectionInfo, new Api(MessagesHandler.MessagesQueue), clientSession);
            MessagesDispatcher = new MessagesDispatcher(MessagesHandler, MtProtoState, clientSession);
            _singleCallAsync = new SingleCallAsync<CancellationToken>(InternalConnectAsync);
            _protocolType = connectionInfo.ConnectionProtocol;
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
            _logger.Information("Stopping loops and creating protocol");
            if (_writeLoop != null)
            {
                //TODO: FIX
                //_writeLoop.Stop();
                await _writeLoop.GetShutdownTask();
            }

            if (_readLoop != null)
            {
                //TODO: FIX
                //_readLoop.Stop();
                await _readLoop.GetShutdownTask();
            }

            if (_pingLoop != null)
            {
                //TODO: FIX
                //_pingLoop.Stop();
                //await _pingLoop.GetShutdownTask();
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
                    StartLoops();
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

        private void StartLoops()
        {
            _writeLoop ??= new SendLoopController(this, _logger);
            _readLoop ??= new ReceiveLoopController(this, _logger);
            _pingLoop ??= new PingLoopController(this, _logger);

            //TODO: FIX
            //_pingLoop.Start();
            //_writeLoop.Start();
            //_readLoop.Start();
        }

        public async ValueTask DisposeAsync()
        {
            var task = MessagesHandler.MessagesTrackers.MessagesAckTracker.GetShutdownTask();
            //TODO: FIX
            //MessagesHandler.MessagesTrackers.MessagesAckTracker.Stop();
            await task;
            
            if (_writeLoop != null)
            {
                //_writeLoop.Stop();
                await _writeLoop.GetShutdownTask();
            }

            if (_readLoop != null)
            {
                //_readLoop.Stop();
                await _readLoop.GetShutdownTask();
            }

            if (_pingLoop != null)
            {
                //_pingLoop.Stop();
                //await _pingLoop.GetShutdownTask();
            }

            Signaler.Dispose();
        }
    }
}