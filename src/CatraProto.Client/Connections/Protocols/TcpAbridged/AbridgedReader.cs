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
using System.Buffers;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Exceptions;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Crypto;
using CatraProto.Client.Extensions;
using Serilog;

namespace CatraProto.Client.Connections.Protocols.TcpAbridged
{
    internal class AbridgedReader : IProtocolReader
    {
        private readonly NetworkStream _networkStream;
        private readonly ILogger _logger;

        public AbridgedReader(NetworkStream stream, ILogger logger)
        {
            _logger = logger.ForContext<AbridgedReader>();
            _networkStream = stream;
        }

        private async ValueTask<int> GetMessageLength(int firstByte, CancellationToken token = default)
        {
            var length = firstByte;
            if (length >= 0x7f)
            {
                length = await _networkStream.ReadByteAsync(token) | await _networkStream.ReadByteAsync(token) << 8 | await _networkStream.ReadByteAsync(token) << 16;
            }

            length *= 4;
            _logger.Verbose("Transport received a message of {Length} ({Byte})", length, firstByte);
            return length;
        }

        public async Task<MemoryStream> ReadMessageAsync(CancellationToken token = default)
        {
            try
            {
                var firstByte = await _networkStream.ReadByteAsync(token);
                var length = await GetMessageLength(firstByte, token);

                // Cannot use CopyTo here because it doesn't allow to specify the maximum length
                var buffer = ArrayPool<byte>.Shared.Rent(length);
                await _networkStream.ReadBytesAsync(buffer, length, token);
                var returnStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream(buffer.AsSpan(0, length));
                ArrayPool<byte>.Shared.Return(buffer);

                return returnStream;
            }
            catch (ObjectDisposedException e) when (e.ObjectName == "System.Net.Sockets.NetworkStream")
            {
                throw new ConnectionClosedException();
            }
        }
    }
}