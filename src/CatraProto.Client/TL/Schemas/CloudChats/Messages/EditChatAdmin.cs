using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class EditChatAdmin : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1470377534;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }


    #nullable enable
        public EditChatAdmin(long chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, bool isAdmin)
        {
            ChatId = chatId;
            UserId = userId;
            IsAdmin = isAdmin;
        }
    #nullable disable

        internal EditChatAdmin()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChatId);
            writer.Write(UserId);
            writer.Write(IsAdmin);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<long>();
            UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            IsAdmin = reader.Read<bool>();
        }

        public override string ToString()
        {
            return "messages.editChatAdmin";
        }
    }
}