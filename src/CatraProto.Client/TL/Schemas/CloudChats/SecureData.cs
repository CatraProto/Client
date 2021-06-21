using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureData : SecureDataBase
    {
        public static int ConstructorId { get; } = -1964327229;
        public override byte[] Data { get; set; }
        public override byte[] DataHash { get; set; }
        public override byte[] Secret { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Data);
            writer.Write(DataHash);
            writer.Write(Secret);
        }

        public override void Deserialize(Reader reader)
        {
            Data = reader.Read<byte[]>();
            DataHash = reader.Read<byte[]>();
            Secret = reader.Read<byte[]>();
        }
    }
}