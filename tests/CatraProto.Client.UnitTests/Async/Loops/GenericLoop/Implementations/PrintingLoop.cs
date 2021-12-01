using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Interfaces;
using Serilog;

namespace CatraProto.Client.UnitTests.Async.Loops.GenericLoop.Implementations
{
    public class PrintingLoop : LoopImplementation<GenericLoopState, GenericSignalState>
    {
        private readonly ILogger _logger;

        public PrintingLoop(ILogger logger)
        {
            _logger = logger;
        }
        
        public override Task LoopAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                var currentState = StateSignaler.GetCurrentState(true);
                if (!currentState!.AlreadyHandled)
                {
                    switch (currentState.Signal)
                    {
                        case GenericSignalState.Start:
                            SetSignalHandled(GenericLoopState.Running, currentState);
                            _logger.Information("Loop started!");
                            break;
                        case GenericSignalState.Stop:
                            SetSignalHandled(GenericLoopState.Stopped, currentState);
                            _logger.Information("Loop stopped!");
                            return Task.CompletedTask;
                    }
                }
                
                _logger.Information("I'm running just fine (until someone kills me :C)!");
            }
        }

        public override string ToString()
        {
            return "Printing genericloop";
        }
    }
}