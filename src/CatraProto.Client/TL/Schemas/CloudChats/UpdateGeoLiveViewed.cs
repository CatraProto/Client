using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateGeoLiveViewed : UpdateBase
    {
        public static int ConstructorId { get; } = -2027964103;
        public PeerBase Peer { get; set; }
        public int MsgId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Peer);
            writer.Write(MsgId);
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<PeerBase>();
            MsgId = reader.Read<int>();
        }
    }
}