using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Interfaces;
using Serilog;

namespace CatraProto.Client.UnitTests.Async.Loops.GenericLoop.Implementations
{
    public class UngracefulLoop : LoopImplementation<GenericLoopState, GenericSignalState>
    {
        private readonly ILogger _logger;

        public UngracefulLoop(ILogger logger)
        {
            _logger = logger.ForContext<UngracefulLoop>();
        }
        
        public override Task LoopAsync(CancellationToken stoppingToken)
        {
            _logger.Information("Now stopping without setting state");
            return Task.CompletedTask;
        }

        public override string ToString()
        {
            return "Ungraceful loop";
        }
    }
}