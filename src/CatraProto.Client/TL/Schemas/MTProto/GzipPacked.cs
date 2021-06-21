using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class GzipPacked : IObject
    {
        public static int ConstructorId { get; } = 812830625;
        public byte[] PackedData { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(PackedData);
        }

        public void Deserialize(Reader reader)
        {
            PackedData = reader.Read<byte[]>();
        }
    }
}