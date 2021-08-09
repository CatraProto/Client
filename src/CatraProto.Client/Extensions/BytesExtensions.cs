using System.Collections.Generic;
using System.IO;
using System.Linq;
using CatraProto.Client.Crypto;

namespace CatraProto.Client.Extensions
{
    public static class BytesExtensions
    {
        public static MemoryStream ToMemoryStream(this byte[] data)
        {
            return new MemoryStream(data);
        }


    }
}