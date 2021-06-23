using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PeerBlocked : PeerBlockedBase
    {
        public static int ConstructorId { get; } = -386039788;
        public override PeerBase PeerId { get; set; }
        public override int Date { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(PeerId);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            PeerId = reader.Read<PeerBase>();
            Date = reader.Read<int>();
        }
    }
}