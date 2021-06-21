using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPhotoLegacyFileLocation : InputFileLocationBase
    {
        public static int ConstructorId { get; } = -667654413;
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public byte[] FileReference { get; set; }
        public long VolumeId { get; set; }
        public int LocalId { get; set; }
        public long Secret { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(AccessHash);
            writer.Write(FileReference);
            writer.Write(VolumeId);
            writer.Write(LocalId);
            writer.Write(Secret);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            AccessHash = reader.Read<long>();
            FileReference = reader.Read<byte[]>();
            VolumeId = reader.Read<long>();
            LocalId = reader.Read<int>();
            Secret = reader.Read<long>();
        }
    }
}