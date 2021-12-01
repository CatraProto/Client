using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Generic;

namespace CatraProto.Client.Async.Loops.Interfaces
{
    public interface ILoop<TLoopState, TSignalState> where TSignalState : Enum where TLoopState : Enum
    {
        public bool SendSignal(TSignalState signal, [MaybeNullWhen(false)] out Task signalHandledTask);
        public bool BindTo(LoopImplementation<TLoopState, TSignalState> loopImplementation);
        public TLoopState GetCurrentState();
        public Task GetShutdownTask();
        
    }
}