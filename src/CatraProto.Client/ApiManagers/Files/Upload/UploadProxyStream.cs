// CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
// Copyright (C) 2022 Aquatica <aquathing@protonmail.com>
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.


using System;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Crypto;

namespace CatraProto.Client.ApiManagers.Files.Upload;

public class UploadProxyStream : IDisposable
{
    private readonly AsyncLock _asyncLock = new AsyncLock();
    private readonly MemoryStream? _backingStream;
    private readonly long _fromOffsetPosition;
    private readonly Stream _sourceStream;
    private readonly long _length;

    public UploadProxyStream(Stream sourceStream, long length)
    {
        _sourceStream = sourceStream;
        _length = length;

        if (!_sourceStream.CanSeek)
        {
            _backingStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
        }
        else
        {
            _fromOffsetPosition = sourceStream.Position;
        }
    }

    public async ValueTask ReadDataAsync(byte[] buffer, int length, long offSet, CancellationToken token)
    {
        using (await _asyncLock.LockAsync(token))
        {
            if (_backingStream is null)
            {
                _sourceStream.Seek(offSet + _fromOffsetPosition, SeekOrigin.Begin);
                await ReadAllAsync(buffer, length, token);
            }
            else
            {
                while (_sourceStream.Length < _length)
                {
                    await _sourceStream.CopyToAsync(_backingStream, token);
                }

                _backingStream.Seek(offSet + _fromOffsetPosition, SeekOrigin.Begin);

                // ReSharper disable once MethodHasAsyncOverloadWithCancellation
                // ReSharper disable once MustUseReturnValue
                _backingStream.Read(buffer, 0, length);
            }
        }
    }

    private async Task ReadAllAsync(byte[] buffer, int length, CancellationToken token)
    {
        var readData = 0;
        while (length > readData)
        {
            var tryRead = await _sourceStream.ReadAsync(buffer, 0, length - readData, token);
            if (tryRead <= 0)
            {
                throw new EndOfStreamException($"The ReadAsync operation from the provided stream returned {tryRead}");
            }

            readData += tryRead;
        }
    }

    public void Dispose()
    {
        _backingStream?.Dispose();
        _asyncLock.Dispose();
    }
}