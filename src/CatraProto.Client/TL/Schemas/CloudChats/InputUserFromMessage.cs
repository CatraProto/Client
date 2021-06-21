using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputUserFromMessage : InputUserBase
    {
        public static int ConstructorId { get; } = 756118935;
        public InputPeerBase Peer { get; set; }
        public int MsgId { get; set; }
        public int UserId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(MsgId);
            writer.Write(UserId);
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            MsgId = reader.Read<int>();
            UserId = reader.Read<int>();
        }
    }
}