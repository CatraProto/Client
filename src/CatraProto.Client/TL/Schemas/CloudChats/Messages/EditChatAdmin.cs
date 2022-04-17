using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class EditChatAdmin : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1470377534; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

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

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChatId);
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }
            var checkisAdmin = writer.WriteBool(IsAdmin);
            if (checkisAdmin.IsError)
            {
                return checkisAdmin;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }
            ChatId = trychatId.Value;
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var tryisAdmin = reader.ReadBool();
            if (tryisAdmin.IsError)
            {
                return ReadResult<IObject>.Move(tryisAdmin);
            }
            IsAdmin = tryisAdmin.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.editChatAdmin";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}