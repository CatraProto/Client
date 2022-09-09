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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Crypto;

namespace CatraProto.Client.ApiManagers.Files.Download;

public class DownloadProxyStream : IDisposable
{
    private readonly Dictionary<int, byte[]> _bytes = new Dictionary<int, byte[]>();
    private readonly AsyncLock _asyncLock = new AsyncLock();
    private readonly Stream _destinationStream;
    private int _waitingForChunk;

    public DownloadProxyStream(Stream destinationStream)
    {
        _destinationStream = destinationStream;
    }

    public async ValueTask WriteChunkAsync(int chunkNumber, byte[] chunk, CancellationToken token = default)
    {
        using (await _asyncLock.LockAsync(token))
        {
            _bytes[chunkNumber] = chunk;
            if (_waitingForChunk == chunkNumber)
            {
                var newWaitingForChunk = _waitingForChunk;
                var writeUntil = -1;
                var ordered = _bytes
                    .OrderBy(x => x.Key)
                    .Select(x => x.Key)
                    .ToList();

                for (var index = 0; index < ordered.Count; index++)
                {
                    var currentChunkNumber = ordered[index];
                    if (currentChunkNumber == _waitingForChunk || ordered[index - 1] + 1 == currentChunkNumber)
                    {
                        newWaitingForChunk = currentChunkNumber + 1;
                        writeUntil = currentChunkNumber;
                        continue;
                    }

                    newWaitingForChunk = ordered[index - 1] + 1;
                    writeUntil = ordered[index - 1];
                    break;
                }

                if (writeUntil >= 0)
                {
                    for (int i = _waitingForChunk; i <= writeUntil; i++)
                    {
                        await _destinationStream.WriteAsync(_bytes[i], token);
                        _bytes.Remove(i);
                    }
                }

                _waitingForChunk = newWaitingForChunk;
            }
        }
    }

    public void Dispose()
    {
        _asyncLock.Dispose();
    }
}