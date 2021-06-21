using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputUser : InputUserBase
    {
        public static int ConstructorId { get; } = -668391402;
        public int UserId { get; set; }
        public long AccessHash { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(AccessHash);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<int>();
            AccessHash = reader.Read<long>();
        }
    }
}