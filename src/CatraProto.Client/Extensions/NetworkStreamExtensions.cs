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
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Exceptions;

namespace CatraProto.Client.Extensions
{
    public static class NetworkStreamExtensions
    {
        public static ValueTask WriteAsync(this NetworkStream stream, byte data, CancellationToken cancellationToken = default)
        {
            var bArray = new byte[1] { data };
            return stream.WriteAsync(bArray, cancellationToken);
        }

        public static async Task<int> ReadInt32Async(this NetworkStream stream, CancellationToken cancellationToken = default)
        {
            var bytes = await stream.ReadBytesAsync(4, cancellationToken);
            return BitConverter.ToInt32(bytes);
        }

        public static async Task<byte[]> ReadBytesAsync(this NetworkStream stream, int count, CancellationToken cancellationToken = default)
        {
            var newBuffer = new byte[count];
            await ReadBytesAsync(stream, newBuffer, count, cancellationToken);
            return newBuffer;
        }

        public static async Task ReadBytesAsync(this NetworkStream stream, byte[] buffer, int count, CancellationToken cancellationToken = default)
        {
            var readCount = 0;
            while (readCount != count)
            {
                readCount += await stream.ReadAsync(buffer, readCount, count - readCount, cancellationToken);
                if (readCount == 0)
                {
                    throw new ConnectionClosedException();
                }
            }
        }

        public static async Task<byte> ReadByteAsync(this NetworkStream stream, CancellationToken cancellationToken = default)
        {
            return (await stream.ReadBytesAsync(1, cancellationToken))[0];
        }
    }
}