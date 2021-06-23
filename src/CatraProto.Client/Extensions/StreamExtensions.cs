using System;
using System.IO;

namespace CatraProto.Client.Extensions
{
	public static class StreamExtensions
	{
		public static void WriteStart(this Stream stream, byte[] data)
		{
			if (stream is MemoryStream ms)
			{
				var buffer = ms.ToArray();
				ms.Seek(0, SeekOrigin.Begin);
				ms.Write(data);
				ms.Write(buffer);
				return;
			}

			throw new NotSupportedException("Non MemoryStream aren't supported");
		}
	}
}