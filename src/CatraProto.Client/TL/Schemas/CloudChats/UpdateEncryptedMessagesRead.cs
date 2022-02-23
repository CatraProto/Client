using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateEncryptedMessagesRead : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => 956179895;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public int ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_date")]
        public int MaxDate { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }


    #nullable enable
        public UpdateEncryptedMessagesRead(int chatId, int maxDate, int date)
        {
            ChatId = chatId;
            MaxDate = maxDate;
            Date = date;
        }
    #nullable disable
        internal UpdateEncryptedMessagesRead()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChatId);
            writer.Write(MaxDate);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            MaxDate = reader.Read<int>();
            Date = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateEncryptedMessagesRead";
        }
    }
}