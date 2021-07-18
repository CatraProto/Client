using System.Threading;

namespace CatraProto.Client.Async.Awaiters
{
    public static class AwaiterExtensions
    {
        public static CancellationTokenAwaiter GetAwaiter(this CancellationToken token)
        {
            return new CancellationTokenAwaiter(token);
        }
    }
}