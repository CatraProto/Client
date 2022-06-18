/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.MTProto.Session.Interfaces;
using Serilog;

namespace CatraProto.Client.MTProto.Session.Deserializers
{
    public class FileSerializer : IAsyncSessionSerializer
    {
        private readonly AsyncLock _lock = new AsyncLock();
        private readonly string _filePath;
        public FileSerializer(string filePath)
        {
            var fileName = Path.GetFileName(filePath) + Path.GetExtension(filePath);
            if (fileName == string.Empty)
            {
                throw new InvalidOperationException("Invalid file name specified");
            }
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

        public async Task SaveAsync(byte[] data, ILogger logger, CancellationToken token)
        {
            using var lk = await _lock.LockAsync(token);
            logger.Information("Writing session file {FileName}. Total length {FileLength} bytes", _filePath, data.Length);
            await File.WriteAllBytesAsync(_filePath, data, token);
        }

        public void Dispose()
        {
            _lock.Dispose();
        }
    }
}
