using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputEncryptedFileLocation : InputFileLocationBase
    {
        public static int ConstructorId { get; } = -182231723;
        public long Id { get; set; }
        public long AccessHash { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(AccessHash);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            AccessHash = reader.Read<long>();
        }
    }
}