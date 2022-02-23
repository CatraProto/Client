using System.IO;
using System.IO.Compression;
using CatraProto.TL.Interfaces;

namespace CatraProto.TL
{
    public static class GzipHandler
    {
        public static MemoryStream ReadGzipPacket(byte[] compressedData)
        {
            var decompressedStream = new MemoryStream();
            using var stream = new GZipStream(compressedData.ToMemoryStream(), CompressionMode.Decompress);
            stream.CopyTo(decompressedStream);
            
            decompressedStream.Seek(0, SeekOrigin.Begin);
            return decompressedStream;
        }

        public static IObject DeserializeGzippedObject(byte[] compressedData, ObjectProvider provider)
        {
            using var reader = new Reader(provider, ReadGzipPacket(compressedData));
            return reader.Read<IObject>();
        }

        public static IObject ToGzipPacket(IObject obj, ObjectProvider provider)
        {
            using var compressedStream = new MemoryStream();
            using var gzipStream = new GZipStream(compressedStream, CompressionMode.Compress);
            gzipStream.Write(obj.ToArray(provider));
            return provider.GetGzippedObject(compressedStream.ToArray());
        }
    }
}