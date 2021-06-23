using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public class MsgCopy : MessageCopyBase
    {
        public static int ConstructorId { get; } = -530561358;
        public override MessageBase OrigMessage { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(OrigMessage);
        }

        public override void Deserialize(Reader reader)
        {
            OrigMessage = reader.Read<MessageBase>();
        }
    }
}