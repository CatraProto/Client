using System;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.MTProto.Settings;
using Serilog;

namespace CatraProto.Client.Connections
{
    internal class LoopsHandler
    {
        private (ReceiveLoop? Loop, GenericLoopController? Controller) _receiveLoop;
        private (SendLoop? Loop, ResumableLoopController? Controller) _writeLoop;
        private (KeyGeneratorLoop? Loop, PeriodicLoopController? Controller) _keyLoop;
        private (PingLoop? Loop, PeriodicLoopController? Controller) _pingLoop;
        private (AckHandlerLoop? Loop, PeriodicLoopController? Controller) _ackLoop;
        private readonly object _mutex = new object();
        private readonly Connection _connection;
        private readonly ClientSettings _clientSettings;
        private readonly ILogger _logger;

        public LoopsHandler(Connection connection, ClientSettings clientSettings, ILogger logger)
        {
            _connection = connection;
            _clientSettings = clientSettings;
            _logger = logger.ForContext<LoopsHandler>();
        }

        public async Task StartLoopsAsync()
        {
            _logger.Information("Starting loops for {Connection}", _connection.ConnectionInfo);
            Task wStart, wSus, rStart, kStart, pStart, aStart;
            lock (_mutex)
            {
                _ackLoop.Loop ??= new AckHandlerLoop(_connection, _logger);
                _ackLoop.Controller = new PeriodicLoopController(TimeSpan.FromSeconds(60), _logger, false);
                _ackLoop.Controller.BindTo(_ackLoop.Loop);
                aStart = _ackLoop.Controller.SignalAsync(ResumableSignalState.Start);

                _keyLoop.Loop ??= new KeyGeneratorLoop(_connection.MtProtoState.KeysHandler.TemporaryAuthKey, _connection, _logger);
                var pfsSeconds = TimeSpan.FromSeconds(_clientSettings.ConnectionSettings.PfsKeyDuration);
                if (_connection.MtProtoState.KeysHandler.TemporaryAuthKey.Exists())
                {
                    var delta = _connection.MtProtoState.KeysHandler.TemporaryAuthKey.GetCachedKey().ExpiresAt!.Value - (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    if (delta > 0)
                    {
                        pfsSeconds = TimeSpan.FromSeconds(delta);
                    }
                }

                _keyLoop.Controller = new PeriodicLoopController(pfsSeconds, _logger);
                _keyLoop.Controller.BindTo(_keyLoop.Loop);
                kStart = _keyLoop.Controller.SignalAsync(ResumableSignalState.Start);

                _receiveLoop.Loop ??= new ReceiveLoop(_connection, _logger);
                _receiveLoop.Controller = new GenericLoopController(_logger);
                _receiveLoop.Controller.BindTo(_receiveLoop.Loop);
                rStart = _receiveLoop.Controller.SignalAsync(GenericSignalState.Start);

                _writeLoop.Loop ??= new SendLoop(_connection, _logger);
                _writeLoop.Controller = new ResumableLoopController(_logger);
                _writeLoop.Controller.BindTo(_writeLoop.Loop);
                wStart = _writeLoop.Controller.SignalAsync(ResumableSignalState.Start);
                wSus = _writeLoop.Controller.SignalAsync(ResumableSignalState.Suspend);

                var seconds = TimeSpan.FromSeconds(_clientSettings.ConnectionSettings.ConnectionTimeout);
                _pingLoop.Loop ??= new PingLoop(seconds, _connection, _logger);
                _pingLoop.Controller = new PeriodicLoopController(seconds, _logger);
                _pingLoop.Controller.BindTo(_pingLoop.Loop);
                pStart = _pingLoop.Controller.SignalAsync(ResumableSignalState.Start);
            }

            await Task.WhenAll(wStart, wSus, rStart, kStart, pStart, aStart);
            _logger.Information("All loops for {Connection} started", _connection.ConnectionInfo);
        }

        public async Task StopLoopsAsync()
        {
            _logger.Information("Stopping loops for {Connection}", _connection.ConnectionInfo);
            Task wStop, rStop, kStop, pStop, aStop;
            lock (_mutex)
            {
                wStop = _writeLoop.Controller is null ? Task.CompletedTask : _writeLoop.Controller.SignalAsync(ResumableSignalState.Stop);
                rStop = _receiveLoop.Controller is null ? Task.CompletedTask : _receiveLoop.Controller.SignalAsync(GenericSignalState.Stop);
                kStop = _keyLoop.Controller is null ? Task.CompletedTask : _keyLoop.Controller.SignalAsync(ResumableSignalState.Stop);
                pStop = _pingLoop.Controller is null ? Task.CompletedTask : _pingLoop.Controller.SignalAsync(ResumableSignalState.Stop);
                aStop = _ackLoop.Controller is null ? Task.CompletedTask : _ackLoop.Controller.SignalAsync(ResumableSignalState.Stop);

                _ackLoop.Controller = null;
                _ackLoop.Loop = null;

                _writeLoop.Loop = null;
                _writeLoop.Controller = null;

                _receiveLoop.Loop = null;
                _receiveLoop.Controller = null;

                _keyLoop.Loop = null;
                _keyLoop.Controller = null;

                _pingLoop.Loop = null;
                _pingLoop.Controller = null;
            }

            await Task.WhenAll(wStop, rStop, kStop, pStop, aStop);
            _logger.Information("All loops for {Connection} stopped", _connection.ConnectionInfo);
        }

        internal void ResetKeyLoop()
        {
            lock (_mutex)
            {
                _keyLoop.Controller?.ChangeInterval(TimeSpan.FromSeconds(_clientSettings.ConnectionSettings.PfsKeyDuration));
            }
        }

        public void WakeUpWriteLoop()
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

        public void WakeUpKeyLoop()
        {
            lock (_mutex)
            {
                _keyLoop.Controller?.SendSignal(ResumableSignalState.Resume, out _);
                _keyLoop.Controller?.ChangeInterval(TimeSpan.FromSeconds(_clientSettings.ConnectionSettings.PfsKeyDuration));
            }
        }
    }
}