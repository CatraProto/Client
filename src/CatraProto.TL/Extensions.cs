using System;
using System.Collections.Generic;
using System.IO;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.TL
{
    public static class Extensions
    {
        public static WriteResult ToArray(this IObject obj, ObjectProvider objectProvider, out byte[] serialized)
        {
            using var writer = new Writer(objectProvider, new MemoryStream());
            var wResult = writer.WriteObject(obj);
            serialized = wResult.IsError ? Array.Empty<byte>() : ((MemoryStream)writer.Stream).ToArray();
            return wResult;
        }

        public static ReadResult<T> ToObject<T>(this Stream stream, ObjectProvider objectProvider) where T : IObject
        {
            using var reader = new Reader(objectProvider, stream, true);
            return reader.ReadObject<T>();
        }

        public static ReadResult<T> ToObject<T>(this byte[] array, ObjectProvider objectProvider) where T : IObject
        {
            using var ms = new MemoryStream(array);
            return ms.ToObject<T>(objectProvider);
        }

        public static ReadResult<List<T>> ToVector<T>(this byte[] array, ObjectProvider objectProvider) where T : IObject
        {
            using var ms = new MemoryStream(array);
            return ms.ToVector<T>(objectProvider);
        }

        public static ReadResult<List<T>> ToVector<T>(this Stream stream, ObjectProvider objectProvider) where T : IObject
        {
            using var reader = new Reader(objectProvider, stream, true);
            return reader.ReadVector<T>(ParserTypes.Object);
        }

        public static MemoryStream ToMemoryStream(this byte[] data)
        {
            return new MemoryStream(data);
        }
    }
}