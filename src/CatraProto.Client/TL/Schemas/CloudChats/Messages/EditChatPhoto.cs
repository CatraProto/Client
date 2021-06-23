using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class EditChatPhoto : IMethod
    {
        public static int ConstructorId { get; } = -900957736;

        public System.Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;
        public int ChatId { get; set; }
        public InputChatPhotoBase Photo { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(ChatId);
            writer.Write(Photo);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            Photo = reader.Read<InputChatPhotoBase>();
        }
    }
}