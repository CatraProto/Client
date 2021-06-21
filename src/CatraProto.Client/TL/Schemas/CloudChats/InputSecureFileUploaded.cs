using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputSecureFileUploaded : InputSecureFileBase
    {
        public static int ConstructorId { get; } = 859091184;
        public override long Id { get; set; }
        public int Parts { get; set; }
        public string Md5Checksum { get; set; }
        public byte[] FileHash { get; set; }
        public byte[] Secret { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(Parts);
            writer.Write(Md5Checksum);
            writer.Write(FileHash);
            writer.Write(Secret);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            Parts = reader.Read<int>();
            Md5Checksum = reader.Read<string>();
            FileHash = reader.Read<byte[]>();
            Secret = reader.Read<byte[]>();
        }
    }
}