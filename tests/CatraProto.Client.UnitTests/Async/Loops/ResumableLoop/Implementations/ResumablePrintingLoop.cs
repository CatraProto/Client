using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Bodies;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Interfaces;
using Serilog;

namespace CatraProto.Client.UnitTests.Async.Loops.ResumableLoop.Implementations
{
    public class ResumablePrintingLoop : LoopImplementation<ResumableLoopState, ResumableSignalState>
    {
        private readonly ILogger _logger;

        public ResumablePrintingLoop(ILogger logger)
        {
            _logger = logger;
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
                    switch (currentState!.Signal)
                    {
                        case ResumableSignalState.Start:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Information("Loop started!");
                            break;
                        case ResumableSignalState.Stop:
                            _logger.Information("Loop stopped!");
                            SetSignalHandled(ResumableLoopState.Stopped, currentState);
                            return;
                        case ResumableSignalState.Resume:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Information("Running again!");
                            break;
                        case ResumableSignalState.Suspend:
                            SetSignalHandled(ResumableLoopState.Suspended, currentState);
                            _logger.Information("Suspended!");
                            currentState = await StateSignaler.WaitAsync(stoppingToken);
                            break;
                    }
                }

                _logger.Information("I'm running just fine (until someone kills me :C)!");
                await Task.Delay(500, stoppingToken);
            }
        }

        public override string ToString()
        {
            return "Resumable printing loop";
        }
    }
}