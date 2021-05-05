using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputEncryptedFileUploaded : InputEncryptedFileBase
    {
        public static int ConstructorId { get; } = 1690108678;
        public long Id { get; set; }
        public int Parts { get; set; }
        public string Md5Checksum { get; set; }
        public int KeyFingerprint { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(Parts);
            writer.Write(Md5Checksum);
            writer.Write(KeyFingerprint);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            Parts = reader.Read<int>();
            Md5Checksum = reader.Read<string>();
            KeyFingerprint = reader.Read<int>();
        }
    }
}