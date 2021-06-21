using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionStopPoll : ChannelAdminLogEventActionBase
    {
        public static int ConstructorId { get; } = -1895328189;
        public MessageBase Message { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Message);
        }

        public override void Deserialize(Reader reader)
        {
            Message = reader.Read<MessageBase>();
        }
    }
}