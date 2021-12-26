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
                    switch (currentState.Signal)
                    {
                        case ResumableSignalState.Start:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Information("Temporary authorization key generator for {Connection}", _connection.ConnectionInfo);
                            break;
                        case ResumableSignalState.Stop:
                            _logger.Information("Temporary authorization key generator for {Connection}", _connection.ConnectionInfo);
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
                            break;
                    }
                }

                if (!_temporaryAuthKey.Exists())
                {
                    _logger.Information("Generating new temporary authorization key because we don't have any");
                    await _temporaryAuthKey.GenerateNewAuthKey(stoppingToken);
                    continue;
                }

                if (_temporaryAuthKey.HasExpired())
                {
                    _logger.Information("Generating new temporary authorization key because the old one has expired");
                    await _temporaryAuthKey.GenerateNewAuthKey(stoppingToken);
                }
            }
        }

        public override string ToString()
        {
            return $"Temporary authorization key generator for {_connection.ConnectionInfo}";
        }
    }
}