using System;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace CatraProto.Client.MTProto.Session.Interfaces
{
    public interface IAsyncSessionSerializer : IDisposable
    {
        public Task<byte[]> ReadAsync(ILogger logger, CancellationToken token);
        public Task SaveAsync(byte[] data, ILogger logger, CancellationToken token);
    }
}