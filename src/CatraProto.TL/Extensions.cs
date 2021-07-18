using System.Collections.Generic;
using System.IO;
using CatraProto.TL.Interfaces;

namespace CatraProto.TL
{
	public static class Extensions
	{
		public static byte[] ToArray(this IObject obj, ObjectProvider objectProvider)
		{
			using var writer = new Writer(objectProvider, new MemoryStream());
			writer.Write(obj);
			return ((MemoryStream)writer.Stream).ToArray();
		}

		public static T ToObject<T>(this Stream stream, ObjectProvider objectProvider)
		{
			using var reader = new Reader(objectProvider, stream, true);
			return reader.Read<T>();
		}

		public static T ToObject<T>(this byte[] array, ObjectProvider objectProvider)
		{
			using var ms = new MemoryStream(array);
			return ms.ToObject<T>(objectProvider);
		}

		public static IList<T> ToVector<T>(this byte[] array, ObjectProvider objectProvider)
		{
			using var ms = new MemoryStream(array);
			return ms.ToVector<T>(objectProvider);
		}

		public static IList<T> ToVector<T>(this Stream stream, ObjectProvider objectProvider)
		{
			using var reader = new Reader(objectProvider, stream, true);
			return reader.ReadVector<T>();
		}
	}
}