using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChatUserTyping : UpdateBase
    {
        public static int ConstructorId { get; } = -1704596961;
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public SendMessageActionBase Action { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ChatId);
            writer.Write(UserId);
            writer.Write(Action);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            UserId = reader.Read<int>();
            Action = reader.Read<SendMessageActionBase>();
        }
    }
}