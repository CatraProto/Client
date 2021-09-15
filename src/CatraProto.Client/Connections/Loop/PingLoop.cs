using System;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class PingLoop : PeriodicLoop
    {
        private readonly Random _random = new Random();
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public PingLoop(Connection connection, ILogger logger) : base(TimeSpan.FromSeconds(5))
        {
            _connection = connection;
            _logger = logger;
            Task.Run(Loop);
        }

        private async Task Loop()
        {
            while (true)
            {
                try
                {
                    await StateSignaler.WaitStateAsync(false, default, ResumableSignalState.Resume, ResumableSignalState.Start);
                    _logger.Information("Sending ping to server");
                    await _connection.MtProtoState.Api.MtProtoApi.PingDelayDisconnectAsync(_random.Next(), 5);
                    _logger.Information("Received pong from server");
                }
                catch (OperationCanceledException e) when (e.CancellationToken == GetShutdownToken())
                {
                    _logger.Information("Ping loop shutdown");
                    break;
                }
            }
        }
    }
}