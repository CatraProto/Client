using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Signalers.Interfaces
{
    public interface IStateSignaler<T>
    {
        public void Signal(T signal);
        public Task<T> WaitAsync(CancellationToken token = default);
    }
}