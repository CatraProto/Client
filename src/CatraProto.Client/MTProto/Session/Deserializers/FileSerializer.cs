using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Session.Interfaces;
using Serilog;

namespace CatraProto.Client.MTProto.Session.Deserializers
{
    public class FileSerializer : IAsyncSessionSerializer
    {
        private readonly string _filePath;
        public FileSerializer(string filePath)
        {
            _filePath = filePath;
        }

        public Task<byte[]> ReadAsync(ILogger logger, CancellationToken token)
        {
            logger.Information("Reading session file {FileName}", _filePath);
            if (!File.Exists(_filePath))
            {
                using (var fileStream = File.Create(_filePath))
                {
                    return Task.FromResult(Array.Empty<byte>());
                }
            }
            return File.ReadAllBytesAsync(_filePath, token);
        }

        public Task SaveAsync(byte[] data, ILogger logger, CancellationToken token)
        {
            logger.Information("Writing session file {FileName}. Total length {FileLength} bytes", _filePath, data.Length);
            return File.WriteAllBytesAsync(_filePath, data, token);
        }

        public void Dispose()
        {
        }
    }
}
