using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePeerBlocked : UpdateBase
    {
        public static int ConstructorId { get; } = 610945826;
        public PeerBase PeerId { get; set; }
        public bool Blocked { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(PeerId);
            writer.Write(Blocked);
        }

        public override void Deserialize(Reader reader)
        {
            PeerId = reader.Read<PeerBase>();
            Blocked = reader.Read<bool>();
        }
    }
}