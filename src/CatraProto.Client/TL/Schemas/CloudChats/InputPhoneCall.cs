using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPhoneCall : InputPhoneCallBase
    {
        public static int ConstructorId { get; } = 506920429;
        public override long Id { get; set; }
        public override long AccessHash { get; set; }

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