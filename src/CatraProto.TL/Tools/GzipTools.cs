using System.IO;
using System.IO.Compression;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.TL
{
    internal static class GzipTools
    {
        public static MemoryStream ReadGzipPacket(byte[] compressedData)
        {
            var decompressedStream = new MemoryStream();
            using var stream = new GZipStream(compressedData.ToMemoryStream(), CompressionMode.Decompress);
            stream.CopyTo(decompressedStream);

            decompressedStream.Seek(0, SeekOrigin.Begin);
            return decompressedStream;
        }

        public static ReadResult<IObject> DeserializeGzippedObject(byte[] compressedData, ObjectProvider provider)
        {
            using var reader = new Reader(provider, ReadGzipPacket(compressedData));
            return reader.ReadObject();
        }
    }
}