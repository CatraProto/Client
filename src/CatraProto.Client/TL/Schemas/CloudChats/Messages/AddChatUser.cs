using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AddChatUser : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -230206493; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("fwd_limit")]
        public int FwdLimit { get; set; }


#nullable enable
        public AddChatUser(long chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int fwdLimit)
        {
            ChatId = chatId;
            UserId = userId;
            FwdLimit = fwdLimit;

        }
#nullable disable

        internal AddChatUser()
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
            writer.WriteInt32(FwdLimit);

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
            var tryfwdLimit = reader.ReadInt32();
            if (tryfwdLimit.IsError)
            {
                return ReadResult<IObject>.Move(tryfwdLimit);
            }
            FwdLimit = tryfwdLimit.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.addChatUser";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}