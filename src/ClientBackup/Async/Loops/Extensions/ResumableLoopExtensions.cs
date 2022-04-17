using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Resumable;

namespace CatraProto.Client.Async.Loops.Extensions
{
    public static class ResumableLoopExtensions
    {
        public static Task<bool> ResumeAndSuspendAsync(this ResumableLoopController controller)
        {
            if (controller.SendSignal(ResumableSignalState.Resume, out var _))
            {
                //Always true unless a race condition occurred, but it is up to the caller to make sure this doesn't happen
                return controller.TrySignalAsync(ResumableSignalState.Suspend);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}