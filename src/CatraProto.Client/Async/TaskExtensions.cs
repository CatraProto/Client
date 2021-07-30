using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async
{
    public static class TaskExtensions
    {
        public static async Task<T> WithCancellationToken<T>(this Task<T> task, CancellationToken token)
        {
            var cancelDelay = new CancellationTokenSource();
            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, cancelDelay.Token);
            
            var result = await Task.WhenAny(task, Task.Delay(-1, linkedTokenSource.Token));
            if (result == task)
            {
                cancelDelay.Cancel();
                return await task;
            }
            else
            {
                await task;
                
                //This return will never be reached because awaiting the Delay task will throw an exception
                return default;
            }
        }
    }
}