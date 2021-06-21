using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputFileLocation : InputFileLocationBase
    {
        public static int ConstructorId { get; } = -539317279;
        public long VolumeId { get; set; }
        public int LocalId { get; set; }
        public long Secret { get; set; }
        public byte[] FileReference { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(VolumeId);
            writer.Write(LocalId);
            writer.Write(Secret);
            writer.Write(FileReference);
        }

        public override void Deserialize(Reader reader)
        {
            VolumeId = reader.Read<long>();
            LocalId = reader.Read<int>();
            Secret = reader.Read<long>();
            FileReference = reader.Read<byte[]>();
        }
    }
}