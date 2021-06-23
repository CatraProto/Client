using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public class GetMessagePublicForwards : IMethod
    {
        public static int ConstructorId { get; } = 1445996571;

        public System.Type Type { get; init; } = typeof(MessagesBase);
        public bool IsVector { get; init; } = false;
        public InputChannelBase Channel { get; set; }
        public int MsgId { get; set; }
        public int OffsetRate { get; set; }
        public InputPeerBase OffsetPeer { get; set; }
        public int OffsetId { get; set; }
        public int Limit { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Channel);
            writer.Write(MsgId);
            writer.Write(OffsetRate);
            writer.Write(OffsetPeer);
            writer.Write(OffsetId);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            MsgId = reader.Read<int>();
            OffsetRate = reader.Read<int>();
            OffsetPeer = reader.Read<InputPeerBase>();
            OffsetId = reader.Read<int>();
            Limit = reader.Read<int>();
        }
    }
}