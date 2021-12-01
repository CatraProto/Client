using System;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Loops.Extensions
{
    public static class LoopExtensions
    {
        public static async Task<bool> TrySignalAsync<TLoopState, TSignalState>(this LoopController<TLoopState, TSignalState> loopController, TSignalState signal) where TLoopState : Enum where TSignalState : Enum
        {
            if (!loopController.SendSignal(signal, out var task))
            {
                return false;
            }

            await task;
            return true;
        }

        public static Task SignalAsync<TLoopState, TSignalState>(this LoopController<TLoopState, TSignalState> loopController, TSignalState signal) where TLoopState : Enum where TSignalState : Enum
        {
            if (!loopController.SendSignal(signal, out var task))
            {
                throw new InvalidOperationException("Failed to send signal");
            }

            return task;
        }
    }
}