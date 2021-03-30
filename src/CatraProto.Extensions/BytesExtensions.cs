using System.IO;

namespace CatraProto.Extensions
{
    public static class BytesExtensions
    {
        public static MemoryStream ToMemoryStream(this byte[] data)
        {
            return new MemoryStream(data);
        }
    }
}