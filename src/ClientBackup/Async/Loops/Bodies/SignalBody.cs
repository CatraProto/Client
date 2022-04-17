using System;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Loops.Bodies
{
    public class SignalBody<TSignal> where TSignal : Enum
    {
        public Task Task
        {
            get => _taskCompletionSource.Task;
        }

        public bool AlreadyHandled
        {
            get => _taskCompletionSource.Task.IsCompleted;
        }

        public TSignal Signal { get; }
        private readonly TaskCompletionSource _taskCompletionSource;

        private SignalBody(TSignal signal, TaskCompletionSource taskCompletionSource)
        {
            Signal = signal;
            _taskCompletionSource = taskCompletionSource;
        }

        public void SetHandled()
        {
            _taskCompletionSource.TrySetResult();
        }

        public void SetCanceled()
        {
            _taskCompletionSource.TrySetCanceled();
        }

        public static SignalBody<TSignal> FromSignal(TSignal signal, out Task signalCompletion)
        {
            var taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            signalCompletion = taskCompletionSource.Task;
            return new SignalBody<TSignal>(signal, taskCompletionSource);
        }

        public static SignalBody<TSignal> FromSignal(TSignal signal, TaskCompletionSource taskCompletionSource)
        {
            return new SignalBody<TSignal>(signal, taskCompletionSource);
        }
    }
}