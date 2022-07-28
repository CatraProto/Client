/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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
            _logger.Information("Starting all loops");
            Task wStart, wSus, rStart, pStart, aStart;
            lock (_mutex)
            {
                _ackLoop.Loop ??= new AckHandlerLoop(_connection, _logger);
                _ackLoop.Controller = new PeriodicLoopController(TimeSpan.FromSeconds(60), _logger, false);
                _ackLoop.Controller.BindTo(_ackLoop.Loop);
                aStart = _ackLoop.Controller.SignalAsync(ResumableSignalState.Start);

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

            await Task.WhenAll(wStart, wSus, rStart, pStart, aStart);
            _logger.Information("All loops started");
        }

        public async Task StopLoopsAsync()
        {
            _logger.Information("Stopping loops");
            Task wStop, rStop, pStop, aStop;
            lock (_mutex)
            {
                wStop = _writeLoop.Controller is null ? Task.CompletedTask : _writeLoop.Controller.SignalAsync(ResumableSignalState.Stop);
                rStop = _receiveLoop.Controller is null ? Task.CompletedTask : _receiveLoop.Controller.SignalAsync(GenericSignalState.Stop);
                pStop = _pingLoop.Controller is null ? Task.CompletedTask : _pingLoop.Controller.SignalAsync(ResumableSignalState.Stop);
                aStop = _ackLoop.Controller is null ? Task.CompletedTask : _ackLoop.Controller.SignalAsync(ResumableSignalState.Stop);

                _ackLoop.Controller = null;
                _ackLoop.Loop = null;

                _writeLoop.Loop = null;
                _writeLoop.Controller = null;

                _receiveLoop.Loop = null;
                _receiveLoop.Controller = null;

                _pingLoop.Loop = null;
                _pingLoop.Controller = null;
            }

            await Task.WhenAll(wStop, rStop, pStop, aStop);
            _logger.Information("All loops stopped");
        }

        public void WakeUpWriteLoop(bool onlyIfSuspended)
        {
            lock (_mutex)
            {
                var getState = _writeLoop.Controller?.GetCurrentState();
                if (onlyIfSuspended && getState is ResumableLoopState.Suspended || !onlyIfSuspended && getState is ResumableLoopState.Running or ResumableLoopState.Suspended)
                {
                    _writeLoop.Controller?.SendSignal(ResumableSignalState.Resume, out _);
                    _writeLoop.Controller?.SendSignal(ResumableSignalState.Suspend, out _);
                }
            }
        }
    }
}