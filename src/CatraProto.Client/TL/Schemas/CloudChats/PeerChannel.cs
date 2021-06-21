using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerChannel : PeerBase
    {
        public static int ConstructorId { get; } = -1109531342;
        public int ChannelId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ChannelId);
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<int>();
        }
    }
}