using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Crypto
{
	class Hashing
	{
		public static byte[] ComputeDataHashedFilling(IObject obj, IObjectProvider provider, int length = 255)
		{
			using var ms = InternalComputeHash(obj, provider);

			if (ms.Length < length)
			{
				var b = new byte[length - ms.Length];
				new Random().NextBytes(b);
				ms.Write(b);
			}

			return ms.ToArray();
		}

		public static byte[] ComputeDataHashedPadding(IObject obj, IObjectProvider provider, int padding = 16)
		{
			using var ms = InternalComputeHash(obj, provider);

			if (ms.Length % 16 == 0)
			{
				return ms.ToArray();
			}

			var b = new byte[16 - ms.Length % 16];
			new Random().NextBytes(b);
			ms.Write(b);

			return ms.ToArray();
		}

		private static MemoryStream InternalComputeHash(IObject obj, IObjectProvider provider)
		{
			var ms = new MemoryStream();

			var serToBytes = obj.ToArray(provider);
			var serToSha1 = SHA1.HashData(serToBytes);

			ms.Write(serToSha1);
			ms.Write(serToBytes);
			return ms;
		}


		public static byte[] ShaBigIntegers(BigInteger bigInteger, BigInteger otherBigInteger)
		{
			using var ms = new MemoryStream();
			ms.Write(bigInteger.ToByteArray());
			ms.Write(otherBigInteger.ToByteArray());
			return SHA1.HashData(ms.ToArray());
		}
	}
}