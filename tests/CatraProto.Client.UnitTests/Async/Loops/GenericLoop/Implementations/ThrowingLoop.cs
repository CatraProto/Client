using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Interfaces;

namespace CatraProto.Client.UnitTests.Async.Loops.GenericLoop.Implementations
{
    public class ThrowingLoop : LoopImplementation<GenericLoopState, GenericSignalState>
    {
        public override Task LoopAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "Throwing genericloop";
        }
    }
}