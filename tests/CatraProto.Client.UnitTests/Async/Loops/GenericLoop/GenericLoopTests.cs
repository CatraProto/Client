using System;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.UnitTests.Async.Loops.GenericLoop.Implementations;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace CatraProto.Client.UnitTests.Async.Loops.GenericLoop
{
    public class GenericLoopTests
    {
        private readonly ILogger _logger;

        public GenericLoopTests(ITestOutputHelper testOutputHelper)
        {
            _logger = SerilogLogger.CreateLogger<GenericLoopTests>(testOutputHelper);
        }

        [Fact(Timeout = 5000)]
        public async Task ThrowsExceptionAsync()
        {
            var genericLoop = new Client.Async.Loops.GenericLoopController(_logger);
            var throwingImpl = new ThrowingLoop();
            genericLoop.BindTo(throwingImpl);
           
            await Assert.ThrowsAsync<TaskCanceledException>(() => genericLoop.SignalAsync(GenericSignalState.Start));
            Assert.Equal(GenericLoopState.Faulted, genericLoop.GetCurrentState());
            await Assert.ThrowsAsync<InvalidOperationException>(() => genericLoop.SignalAsync(GenericSignalState.Stop));
            
            await WaitShutdownAsync(genericLoop);
        }
        
        [Fact(Timeout = 5000)]
        public async Task TwoTimesStartAsync()
        {
            var genericLoop = new Client.Async.Loops.GenericLoopController(_logger);
            var printingLoop = new PrintingLoop(_logger);
            genericLoop.BindTo(printingLoop);
            
            var exceptionAsync = await Record.ExceptionAsync(() => genericLoop.SignalAsync(GenericSignalState.Start));
            Assert.Null(exceptionAsync);
            
            await Assert.ThrowsAsync<InvalidOperationException>(() => genericLoop.SignalAsync(GenericSignalState.Start));

            exceptionAsync = await Record.ExceptionAsync(() => genericLoop.SignalAsync(GenericSignalState.Stop));
            Assert.Null(exceptionAsync);
            
            await WaitShutdownAsync(genericLoop);
        }
        
        [Fact(Timeout = 5000)]
        public async Task UngracefulShutdownLoop()
        {
            var genericLoop = new Client.Async.Loops.GenericLoopController(_logger);
            var ungracefulLoop = new UngracefulLoop(_logger);
            genericLoop.BindTo(ungracefulLoop);
            genericLoop.SendSignal(GenericSignalState.Start, out var task);
            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
            Assert.Equal(GenericLoopState.Faulted, genericLoop.GetCurrentState());
        }

        internal Task WaitShutdownAsync(Client.Async.Loops.GenericLoopController loopController)
        {
            return loopController.GetShutdownTask();
        }
    }
}