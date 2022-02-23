using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateEncryption : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -1264392051;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chat")] public CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase Chat { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }


    #nullable enable
        public UpdateEncryption(CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase chat, int date)
        {
            Chat = chat;
            Date = date;
        }
    #nullable disable
        internal UpdateEncryption()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Chat);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            Chat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>();
            Date = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateEncryption";
        }
    }
}