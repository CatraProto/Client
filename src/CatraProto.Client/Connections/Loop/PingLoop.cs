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
                            _logger.Information("Ping loop started for connection {Connection}", _connection.ConnectionInfo);
                            break;
                        case ResumableSignalState.Stop:
                            _logger.Information("Ping loop stopped for connection {Connection}", _connection.ConnectionInfo);
                            SetSignalHandled(ResumableLoopState.Stopped, currentState);
                            return;
                        case ResumableSignalState.Resume:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Verbose("Ping loop for connection {Connection} woken up", _connection.ConnectionInfo);
                            break;
                        case ResumableSignalState.Suspend:
                            SetSignalHandled(ResumableLoopState.Suspended, currentState);
                            _logger.Verbose("Ping loop for connection {Connection} paused. Waiting for signal...", _connection.ConnectionInfo);
                            currentState = await StateSignaler.WaitAsync(stoppingToken);
                            break;
                    }
                }

                using var timeout = new CancellationTokenSource(_timeout);
                using var linked = CancellationTokenSource.CreateLinkedTokenSource(timeout.Token, stoppingToken);

                try
                {
                    if (_connection.MtProtoState.KeysHandler.TemporaryAuthKey.CanBeUsed())
                    {
                        _logger.Information("Sending ping to server {Connection} with timeout of {Time} seconds", _connection.ConnectionInfo, _timeout.TotalSeconds);
                        await _connection.MtProtoState.Api.MtProtoApi.PingAsync(CryptoTools.CreateRandomLong(), cancellationToken: linked.Token);
                        _logger.Information("Received pong from server {Connection}", _connection.ConnectionInfo);
                    }
                }
                catch (OperationCanceledException) when (timeout.Token.IsCancellationRequested)
                {
                    _logger.Warning("Didn't receive reply to ping in {Timeout} seconds, reconnecting to {Connection}", _timeout.TotalSeconds, _connection.ConnectionInfo);
                    _ = _connection.ConnectAsync(CancellationToken.None);
                    SetLoopState(ResumableLoopState.Stopped);
                    return;
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    _logger.Information("Ping not completed because loop received stop signal on {Connection}", _connection.ConnectionInfo);
                    SetLoopState(ResumableLoopState.Stopped);
                    return;
                }
            }
        }

        public override string ToString()
        {
            return $"Ping loop for {_connection.ConnectionInfo}";
        }
    }
}