using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Extensions
{
	public static class NetworkStreamExtensions
	{
		public static ValueTask WriteAsync(this NetworkStream stream, byte data, CancellationToken cancellationToken = default)
		{
			var bArray = new byte[1] { data };
			return stream.WriteAsync(bArray, cancellationToken);
		}

		public static async Task<int> ReadInt32(this NetworkStream stream)
		{
			var bytes = await stream.ReadBytesAsync(4);
			return BitConverter.ToInt32(bytes);
		}

		public static async Task<byte[]> ReadBytesAsync(this NetworkStream stream, int count, int offset = 0,
			CancellationToken cancellationToken = default)
		{
			var buffer = new byte[count];
			await stream.ReadAsync(buffer.AsMemory(offset, count), cancellationToken);
			return buffer;
		}

		public static async Task<byte> ReadByte(this NetworkStream stream,
			int offset = 0,
			CancellationToken cancellationToken = default)
		{
			var buffer = new byte[1];
			await stream.ReadAsync(buffer.AsMemory(offset, 1), cancellationToken);
			return buffer[0];
		}
	}
}