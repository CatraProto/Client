using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateEncryptedChatTyping : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 386986326; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public int ChatId { get; set; }


#nullable enable
        public UpdateEncryptedChatTyping(int chatId)
        {
            ChatId = chatId;

        }
#nullable disable
        internal UpdateEncryptedChatTyping()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(ChatId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatId = reader.ReadInt32();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }
            ChatId = trychatId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateEncryptedChatTyping";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}