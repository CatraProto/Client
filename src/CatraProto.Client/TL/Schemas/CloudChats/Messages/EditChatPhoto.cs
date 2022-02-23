using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class EditChatPhoto : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 903730804;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase Photo { get; set; }


    #nullable enable
        public EditChatPhoto(long chatId, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo)
        {
            ChatId = chatId;
            Photo = photo;
        }
    #nullable disable

        internal EditChatPhoto()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChatId);
            writer.Write(Photo);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<long>();
            Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase>();
        }

        public override string ToString()
        {
            return "messages.editChatPhoto";
        }
    }
}