using System;
using System.IO;
using System.IO.Compression;
using CatraProto.Client.Extensions;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto
{
    static class GzipHandler
    {
        public static MemoryStream ReadGzipPacket(byte[] compressedData)
        {
            var decompressedStream = new MemoryStream();
            using var stream = new GZipStream(compressedData.ToMemoryStream(), CompressionMode.Decompress);
            stream.CopyTo(decompressedStream);
            decompressedStream.Seek(0, SeekOrigin.Begin);
            return decompressedStream;
        }

        public static IObject DeserializeGzip(byte[] compressedData)
        {
            using var reader = new Reader(MergedProvider.Singleton, ReadGzipPacket(compressedData));
            return reader.Read<IObject>();
        }
    }
}