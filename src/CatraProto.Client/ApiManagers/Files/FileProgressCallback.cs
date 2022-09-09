using System;
using System.Threading.Tasks;

namespace CatraProto.Client.ApiManagers.Files;

public class FileProgressCallback
{
    internal Func<long, Task> Callback { get; }

    public FileProgressCallback(Func<long, Task> callback)
    {
        Callback = callback;
    }

    public FileProgressCallback(Action<long> callback)
    {
        Callback = (progress) =>
        {
            callback(progress);
            return Task.CompletedTask;
        };
    }
}