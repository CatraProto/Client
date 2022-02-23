using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatInviteAlready : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
    {
        public static int StaticConstructorId
        {
            get => 1516793212;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chat")] public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }


    #nullable enable
        public ChatInviteAlready(CatraProto.Client.TL.Schemas.CloudChats.ChatBase chat)
        {
            Chat = chat;
        }
    #nullable disable
        internal ChatInviteAlready()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Chat);
        }

        public override void Deserialize(Reader reader)
        {
            Chat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
        }

        public override string ToString()
        {
            return "chatInviteAlready";
        }
    }
}