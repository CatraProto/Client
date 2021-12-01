using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.UnitTests.Async.Loops.ResumableLoop.Implementations;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace CatraProto.Client.UnitTests.Async.Loops.ResumableLoop
{
    public class ResumableLoopTests
    {
        private readonly ILogger _logger;
        public ResumableLoopTests(ITestOutputHelper helper)
        {
            _logger = SerilogLogger.CreateLogger<ResumableLoopTests>(helper);
        }
        
        [Fact]
        public void CantSendIfNotStarted()
        {
            var loopController = new ResumableLoopController(_logger);
            var loopInstance = new ResumablePrintingLoop(_logger);
            loopController.BindTo(loopInstance);

            Assert.False(loopController.SendSignal(ResumableSignalState.Resume, out _));
            Assert.False(loopController.SendSignal(ResumableSignalState.Suspend, out _));
            Assert.False(loopController.SendSignal(ResumableSignalState.Stop, out _));
        }
        
        [Fact]
        public async Task CantSendIfStopped()
        {
            var loopController = new ResumableLoopController(_logger);
            var loopInstance = new ResumablePrintingLoop(_logger);
            loopController.BindTo(loopInstance);

            await loopController.SignalAsync(ResumableSignalState.Start);
            await loopController.SignalAsync(ResumableSignalState.Stop);

            Assert.False(loopController.SendSignal(ResumableSignalState.Start, out _));
            Assert.False(loopController.SendSignal(ResumableSignalState.Resume, out _));
            Assert.False(loopController.SendSignal(ResumableSignalState.Suspend, out _));
            Assert.False(loopController.SendSignal(ResumableSignalState.Stop, out _));
        }
        
        [Fact]
        public async Task CantSendIfSuspended()
        {
            var loopController = new ResumableLoopController(_logger);
            var loopInstance = new ResumablePrintingLoop(_logger);
            loopController.BindTo(loopInstance);

            await loopController.SignalAsync(ResumableSignalState.Start);
            await loopController.SignalAsync(ResumableSignalState.Suspend);

            Assert.False(loopController.SendSignal(ResumableSignalState.Start, out _));
            Assert.False(loopController.SendSignal(ResumableSignalState.Suspend, out _));
        }
        
        [Fact]
        public async Task CantSendIfResumed()
        {
            var loopController = new ResumableLoopController(_logger);
            var loopInstance = new ResumablePrintingLoop(_logger);
            loopController.BindTo(loopInstance);

            await loopController.SignalAsync(ResumableSignalState.Start);
            await loopController.SignalAsync(ResumableSignalState.Suspend);
            await loopController.SignalAsync(ResumableSignalState.Resume);

            Assert.False(loopController.SendSignal(ResumableSignalState.Start, out _));
        }
    }
}