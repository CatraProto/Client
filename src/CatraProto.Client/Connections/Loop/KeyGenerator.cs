using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class KeyGenerator : LoopImplementation<ResumableLoopState, ResumableSignalState>
    {
        private readonly TemporaryAuthKey _temporaryAuthKey;
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public KeyGenerator(TemporaryAuthKey temporaryAuthKey, Connection connection, ILogger logger)
        {
            _temporaryAuthKey = temporaryAuthKey;
            _connection = connection;
            _logger = logger.ForContext<KeyGenerator>();
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
                            _logger.Information("Temporary authorization key generator for {Connection} started", _connection.ConnectionInfo);
                            break;
                        case ResumableSignalState.Stop:
                            _logger.Information("Temporary authorization key generator for {Connection} stopped", _connection.ConnectionInfo);
                            SetSignalHandled(ResumableLoopState.Stopped, currentState);
                            return;
                        case ResumableSignalState.Resume:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Verbose("Temporary authorization key generator for {Connection} woken up", _connection.ConnectionInfo);
                            break;
                        case ResumableSignalState.Suspend:
                            SetSignalHandled(ResumableLoopState.Suspended, currentState);
                            _logger.Verbose("Temporary authorization key generator for {Connection} paused. Waiting for signal...", _connection.ConnectionInfo);
                            currentState = await StateSignaler.WaitAsync(stoppingToken);
                            skipCycle = true;
                            break;
                    }

                    if (skipCycle)
                    {
                        continue;
                    }
                }

                using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(1));
                using var linked = CancellationTokenSource.CreateLinkedTokenSource(timeout.Token, stoppingToken);
                
                Task<bool>? task = null;
                if (!_temporaryAuthKey.Exists())
                {
                    _logger.Information("Generating new temporary authorization key because we don't have any");
                    task = _temporaryAuthKey.GenerateNewAuthKey(linked.Token);
                }
                else if (!_temporaryAuthKey.CanBeUsed())
                {
                    _logger.Information("Generating new temporary authorization key because the old one has expired");
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
                            _ = _connection.ConnectAsync(CancellationToken.None);
                            continue;
                        }
                    }

                    if (!_connection.GetIsInited())
                    {
                        await _connection.InitConnectionAsync(stoppingToken);
                        _connection.WakeUpLoop();
                    }
                }
                catch (OperationCanceledException) when (timeout.Token.IsCancellationRequested)
                {
                    _logger.Warning("Authorization key was not generated after 1 minute, reconnecting");
                    _ = _connection.ConnectAsync(CancellationToken.None);
                    SetLoopState(ResumableLoopState.Stopped);
                    return;
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    _logger.Information("Authorization key was not generated or connection wasn't initialized because loop received stop signal");
                    SetLoopState(ResumableLoopState.Stopped);
                    return;
                }
            }
        }

        public override string ToString()
        {
            return $"Temporary authorization key generator for {_connection.ConnectionInfo}";
        }
    }
}