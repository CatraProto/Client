using System.IO;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;

namespace CatraProto.Client.TL
{
    public class Utilities
    {
        public static Reader CreateReader(Stream stream)
        {
            return new Reader(MergedProvider.Singleton, stream);
        }
        
        public static Writer CreateWriter(Stream stream)
        {
            return new Writer(MergedProvider.Singleton, stream);
        }
        
        public static Reader CreateReader()
        {
            return CreateReader(new MemoryStream());
        }
        
        public static Writer CreateWriter()
        {
            return CreateWriter(new MemoryStream());
        }
    }
}