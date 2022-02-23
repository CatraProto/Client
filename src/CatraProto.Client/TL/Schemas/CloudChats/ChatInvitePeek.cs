using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatInvitePeek : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
    {
        public static int StaticConstructorId
        {
            get => 1634294960;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chat")] public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public int Expires { get; set; }


    #nullable enable
        public ChatInvitePeek(CatraProto.Client.TL.Schemas.CloudChats.ChatBase chat, int expires)
        {
            Chat = chat;
            Expires = expires;
        }
    #nullable disable
        internal ChatInvitePeek()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Chat);
            writer.Write(Expires);
        }

        public override void Deserialize(Reader reader)
        {
            Chat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Expires = reader.Read<int>();
        }

        public override string ToString()
        {
            return "chatInvitePeek";
        }
    }
}