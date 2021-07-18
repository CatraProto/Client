using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Awaiters
{
    public class CancellationTokenAwaiter : INotifyCompletion
    {
        public bool IsCompleted
        {
            get => _token.IsCancellationRequested;
        } 
        
        private CancellationToken _token;
        public CancellationTokenAwaiter(CancellationToken token)
        {
            _token = token;
        }

        public void GetResult()
        {
            if (!IsCompleted)
            {
                _token.WaitHandle.WaitOne();
            }
        }
        
        public void OnCompleted(Action continuation)
        {
            _token.Register(continuation);
        }

        public static async Task AwaitToken(CancellationToken token)
        {
            await token;
        }
    }
}