using System;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Loops.Interfaces
{
    public interface ILoop<in TSignalState> where TSignalState : Enum
    {
        public void SendSignal(TSignalState state);
        public CancellationToken GetShutdownToken();
        public Task GetShutdownTask();
    }
}