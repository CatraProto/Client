using System.Linq;

namespace CatraProto.TL
{
	static class BigInteger
	{
		internal static System.Numerics.BigInteger ReadBytes(int bitSize, Reader reader)
		{
			var byteCount = bitSize / 8;
			var bytes = new byte[byteCount];

			for (var i = 0; i < byteCount; i++)
			{
				bytes[i] = reader.Read<byte>();
			}

			return new System.Numerics.BigInteger(bytes);
		}

		public static byte[] RemoveTrailingZeros(this byte[] array)
		{
			return array.Reverse().SkipWhile(x => x == 0).Reverse().ToArray();
		}
	}
}