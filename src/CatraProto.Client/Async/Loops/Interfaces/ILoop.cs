using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Loops.Interfaces
{
    public interface ILoop
    {
        public bool Start();
        public bool Stop();
    }
}