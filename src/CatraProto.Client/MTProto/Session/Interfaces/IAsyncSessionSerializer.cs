using System;
using System.Threading.Tasks;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.MTProto.Session.Interfaces
{
    public interface IAsyncSessionSerializer : IDisposable
    {
        public Task<byte[]> ReadAsync(ILogger logger);
        public Task SaveAsync(byte[] data, ILogger logger);
    }
}