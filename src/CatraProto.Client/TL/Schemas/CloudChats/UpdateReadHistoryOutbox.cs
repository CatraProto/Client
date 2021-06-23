using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateReadHistoryOutbox : UpdateBase
    {
        public static int ConstructorId { get; } = 791617983;
        public PeerBase Peer { get; set; }
        public int MaxId { get; set; }
        public int Pts { get; set; }
        public int PtsCount { get; set; }

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
            writer.Write(MaxId);
            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<PeerBase>();
            MaxId = reader.Read<int>();
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }
    }
}