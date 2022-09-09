using CatraProto.Client.Tools;
using Serilog;

namespace CatraProto.Client.ApiManagers.Files;

internal class FileProgressInvoker
{
    private readonly SequentialInvoker _sequentialInvoker;
    private readonly FileProgressCallback _callback;
    private readonly object _mutex = new object();
    private long _currentProgress = 0;

    public FileProgressInvoker(FileProgressCallback callback, ILogger logger)
    {
        _callback = callback;
        _sequentialInvoker = new SequentialInvoker(logger);
    }

    public void Invoke(long increaseBy)
    {
        lock (_mutex)
        {
            _currentProgress += increaseBy;
            _sequentialInvoker.Invoke(() => _callback.Callback(_currentProgress));
        }
    }
}