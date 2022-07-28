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
using CatraProto.Client.Connections;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKey
{
    internal class KeyGeneratorLoop : LoopImplementation<ResumableLoopState, ResumableSignalState>
    {
        private readonly TemporaryAuthKey _temporaryAuthKey;
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public KeyGeneratorLoop(TemporaryAuthKey temporaryAuthKey, Connection connection, ILogger logger)
        {
            _temporaryAuthKey = temporaryAuthKey;
            _connection = connection;
            _logger = logger.ForContext<KeyGeneratorLoop>();
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
                    var skipCycle = false;
                    switch (currentState.Signal)
                    {
                        case ResumableSignalState.Start:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Information("Temporary authorization key generator started");
                            break;
                        case ResumableSignalState.Stop:
                            _logger.Information("Temporary authorization key generator stopped");
                            SetSignalHandled(ResumableLoopState.Stopped, currentState);
                            return;
                        case ResumableSignalState.Resume:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Verbose("Temporary authorization key generator woken up");
                            break;
                        case ResumableSignalState.Suspend:
                            SetSignalHandled(ResumableLoopState.Suspended, currentState);
                            _logger.Verbose("Temporary authorization key generator paused. Waiting for signal...");
                            currentState = await StateSignaler.WaitAsync(stoppingToken);
                            skipCycle = true;
                            break;
                    }

                    if (skipCycle)
                    {
                        continue;
                    }
                }

                while (true)
                {
                    using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(1));
                    using var linked = CancellationTokenSource.CreateLinkedTokenSource(timeout.Token, stoppingToken);

                    Task<bool>? task = null;
                    if (!_temporaryAuthKey.Exists())
                    {
                        _logger.Information("Generating new temporary authorization key because we don't have any ");
                        task = _temporaryAuthKey.GenerateNewAuthKey(linked.Token);
                    }
                    else if (!_temporaryAuthKey.CanBeUsed())
                    {
                        _logger.Information("Generating new temporary authorization key because the old one has expired ");
                        task = _temporaryAuthKey.GenerateNewAuthKey(linked.Token);
                    }

                    try
                    {
                        if (task is not null)
                        {
                            var result = await task;
                            if (!result)
                            {
                                _logger.Warning("Failed to generate authorization key, reconnecting...");
                                await _connection.ConnectAsync(CancellationToken.None);
                                continue;
                            }
                            _connection.OnKeyGenerated();
                        }
                        break;
                    }
                    catch (OperationCanceledException) when (timeout.Token.IsCancellationRequested)
                    {
                        _logger.Warning("Authorization key was not generated after 1 minute, reconnecting...");
                        await _connection.ConnectAsync(CancellationToken.None);
                    }
                    catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                    {
                        _logger.Information("Authorization key was not generated or connection wasn't initialized because loop received stop signal");
                        SetLoopState(ResumableLoopState.Stopped);
                        return;
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Temporary authorization key generator";
        }
    }
}