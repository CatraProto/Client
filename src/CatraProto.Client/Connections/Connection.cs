using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Connections.Protocols.TcpAbridged;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Settings;
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
        public IProtocol Protocol { get; private set; }

        private readonly SingleCallAsync<CancellationToken> _singleCallAsync;
        private readonly ClientSettings _clientSettings;
        private readonly ConnectionProtocol _protocolType;
        private readonly object _mutex = new object();
        private (ReceiveLoop? Loop, GenericLoopController? Controller) _receiveLoop;
        private (SendLoop? Loop, ResumableLoopController? Controller) _writeLoop;
        private (KeyGenerator? Loop, PeriodicLoopController? Controller) _periodicLoopController;
        private readonly ILogger _logger;
        private bool _isInited;

        public Connection(ConnectionInfo connectionInfo, ClientSession clientSession)
        {
            _logger = clientSession.Logger.ForContext<Connection>();
            ConnectionInfo = connectionInfo;
            MessagesHandler = new MessagesHandler(this, clientSession.Logger);
            MtProtoState = new MTProtoState(this, new Api(MessagesHandler.MessagesQueue), clientSession);
            _clientSettings = clientSession.Settings;
            MessagesDispatcher = new MessagesDispatcher(this, MessagesHandler, MtProtoState, clientSession);
            _singleCallAsync = new SingleCallAsync<CancellationToken>(InternalConnectAsync);
            _protocolType = connectionInfo.ConnectionProtocol;
            Protocol = CreateProtocol();
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
            await Protocol.CloseAsync();

            Protocol = CreateProtocol();
            while (true)
            {
                try
                {
                    _logger.Information("Connecting to {Connection}", ConnectionInfo);
                    await Protocol.ConnectAsync(token);
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error("Couldn't connect due to {Message}, trying again in 3 seconds", e.Message);
                    await Task.Delay(3000, token);
                }
            }
            
            _logger.Information("Successfully connected to {Connection}", ConnectionInfo);
            await StartLoops();
        }

        private async Task StartLoops()
        {
            _logger.Information("Starting loops for {Connection}", ConnectionInfo);
            Task wStart;
            Task wSus;
            Task rStart;
            Task pStart;
            lock (_mutex)
            {
                _receiveLoop.Loop ??= new ReceiveLoop(this, _logger);
                _receiveLoop.Controller = new GenericLoopController(_logger);
                _receiveLoop.Controller.BindTo(_receiveLoop.Loop);
                rStart = _receiveLoop.Controller.SignalAsync(GenericSignalState.Start);

                _writeLoop.Loop ??= new SendLoop(_clientSettings.ApiSettings, this, _logger);
                _writeLoop.Controller = new ResumableLoopController(_logger);
                _writeLoop.Controller.BindTo(_writeLoop.Loop);
                wStart = _writeLoop.Controller.SignalAsync(ResumableSignalState.Start);   
                wSus = _writeLoop.Controller.SignalAsync(ResumableSignalState.Suspend);


                _periodicLoopController.Loop ??= new KeyGenerator(MtProtoState.KeysHandler.TemporaryAuthKey, this, _logger);
                _periodicLoopController.Controller = new PeriodicLoopController(TimeSpan.FromSeconds(_clientSettings.ConnectionSettings.PfsKeyDuration), _logger);
                _periodicLoopController.Controller.BindTo(_periodicLoopController.Loop);
                pStart = _periodicLoopController.Controller.SignalAsync(ResumableSignalState.Start);
            }
            
            await Task.WhenAll(wStart, wSus, rStart, pStart);
            _logger.Information("All loops for {Connection} started", ConnectionInfo);
        }

        private async Task StopLoops()
        {
            var t1 = _writeLoop.Controller?.SignalAsync(ResumableSignalState.Stop);
            var t2 = _receiveLoop.Controller?.SignalAsync(GenericSignalState.Stop);
            await Task.WhenAll(t1, t2);
        }
        
        public void WakeUpLoop()
        {
            lock (_mutex)
            {
                if (_writeLoop.Controller?.GetCurrentState() is ResumableLoopState.Running or ResumableLoopState.Suspended)
                {
                    _writeLoop.Controller?.SendSignal(ResumableSignalState.Resume, out _);
                    _writeLoop.Controller?.SendSignal(ResumableSignalState.Suspend, out _);   
                }
            }
        }
        
        public Task RegenKey()
        {
            Task task;
            lock (_mutex)
            {
                if (_periodicLoopController.Controller is not null)
                {
                    _logger.Information("Waking up loop to regen key and resetting timer");
                    task = _periodicLoopController.Controller.SignalAsync(ResumableSignalState.Resume);
                    _periodicLoopController.Controller.ChangeInterval(TimeSpan.FromSeconds(_clientSettings.ConnectionSettings.PfsKeyDuration));
                }
                else
                {
                    _logger.Information("Periodic loop controller is not set");
                    task = Task.CompletedTask;
                }
            }

            return task;
        }

        public bool GetIsInited()
        {
            lock (_mutex)
            {
                return _isInited;
            }
        }

        public void SetIsInited(bool value)
        {
            lock (_mutex)
            {
                _isInited = value;
            }
        }
        
        public async ValueTask DisposeAsync()
        {
            var task = MessagesHandler.MessagesTrackers.MessagesAckTracker.GetShutdownTask();
            //TODO: FIX
            //MessagesHandler.MessagesTrackers.MessagesAckTracker.Stop();
            await task;
            await StopLoops();
            Signaler.Dispose();
        }
    }
}