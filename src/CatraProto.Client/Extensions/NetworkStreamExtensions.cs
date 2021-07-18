using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Exceptions;

namespace CatraProto.Client.Extensions
{
    public static class NetworkStreamExtensions
    {
        public static ValueTask WriteAsync(this NetworkStream stream, byte data,
            CancellationToken cancellationToken = default)
        {
            var bArray = new byte[1] { data };
            return stream.WriteAsync(bArray, cancellationToken);
        }

        public static async Task<int> ReadInt32(this NetworkStream stream)
        {
            var bytes = await stream.ReadBytesAsync(4);
            return BitConverter.ToInt32(bytes);
        }

        public static async Task<byte[]> ReadBytesAsync(this NetworkStream stream, int count, CancellationToken cancellationToken = default)
        {
            var buffer = new byte[count];
            var readCount = 0;
            while (readCount != buffer.Length)
            {
                readCount += await stream.ReadAsync(buffer, readCount, count, cancellationToken);
                if (readCount == 0)
                {
                    throw new ConnectionClosedException();
                }
            }

            return buffer;
        }

        public static async Task<byte> ReadByte(this NetworkStream stream, CancellationToken cancellationToken = default)
        {
            return (await stream.ReadBytesAsync(1, cancellationToken: cancellationToken))[0];
        }
    }
}