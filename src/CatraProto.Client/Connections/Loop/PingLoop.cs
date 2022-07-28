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
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Crypto;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    internal class PingLoop : LoopImplementation<ResumableLoopState, ResumableSignalState>
    {
        private readonly TimeSpan _timeout;
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public PingLoop(TimeSpan timeout, Connection connection, ILogger logger)
        {
            _timeout = timeout;
            _connection = connection;
            _logger = logger.ForContext<PingLoop>();
        }

        public override async Task LoopAsync(CancellationToken stoppingToken)
        {
            var currentState = StateSignaler.GetCurrentState(true);
            while (true)
            {
                if (currentState!.AlreadyHandled)
                {
                    currentState = StateSignaler.GetCurrentState(true);
                }

                if (!currentState!.AlreadyHandled)
                {
                    switch (currentState.Signal)
                    {
                        case ResumableSignalState.Start:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Information("Ping loop started");
                            break;
                        case ResumableSignalState.Stop:
                            _logger.Information("Ping loop stopped");
                            SetSignalHandled(ResumableLoopState.Stopped, currentState);
                            return;
                        case ResumableSignalState.Resume:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Verbose("Ping loop woken up");
                            break;
                        case ResumableSignalState.Suspend:
                            SetSignalHandled(ResumableLoopState.Suspended, currentState);
                            _logger.Verbose("Ping loop paused. Waiting for signal...");
                            currentState = await StateSignaler.WaitAsync(stoppingToken);
                            break;
                    }
                }

                using var timeout = new CancellationTokenSource(_timeout);
                using var linked = CancellationTokenSource.CreateLinkedTokenSource(timeout.Token, stoppingToken);

                try
                {
                    if (_connection.MtProtoState.KeyManager!.TemporaryAuthKey.CanBeUsed())
                    {
                        _logger.Information("Sending ping to server with timeout of {Time} seconds", _timeout.TotalSeconds);
                        await _connection.MtProtoState.Api.MtProtoApi.PingAsync(CryptoTools.CreateRandomLong(), cancellationToken: linked.Token);
                        _logger.Information("Received pong from server");
                    }
                }
                catch (OperationCanceledException) when (timeout.Token.IsCancellationRequested)
                {
                    _logger.Warning("Didn't receive reply to ping in {Timeout} seconds, reconnecting...", _timeout.TotalSeconds);
                    _ = _connection.ConnectAsync(CancellationToken.None);
                    SetLoopState(ResumableLoopState.Stopped);
                    return;
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    _logger.Information("Ping not completed because loop received stop signal");
                    SetLoopState(ResumableLoopState.Stopped);
                    return;
                }
            }
        }

        public override string ToString()
        {
            return $"Ping loop";
        }
    }
}