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
        private readonly Api _api;
        private readonly ILogger _logger;

        public PingLoop(Api api, ILogger logger) : base(TimeSpan.FromMinutes(2))
        {
            _api = api;
            _logger = logger;
            Task.Run(Loop);
        }

        private async Task Loop()
        {
            while (true)
            {
                try
                {
                    await StateSignaler.WaitStateAsync(default, ResumableSignalState.Resume, ResumableSignalState.Start);
                    _logger.Information("Sending ping to server");
                    await _api.MtProtoApi.PingAsync(_random.Next());
                    _logger.Information("Received pong from server");
                }
                catch (OperationCanceledException e) when (e.CancellationToken == GetShutdownToken())
                {
                    _logger.Information("Ping loop shutdown");
                    SetLoopStopped();
                    break;
                }
            }
        }
    }
}