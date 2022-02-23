using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionEditMessage : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        public static int StaticConstructorId
        {
            get => 1889215493;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("prev_message")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageBase PrevMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("new_message")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageBase NewMessage { get; set; }


    #nullable enable
        public ChannelAdminLogEventActionEditMessage(CatraProto.Client.TL.Schemas.CloudChats.MessageBase prevMessage, CatraProto.Client.TL.Schemas.CloudChats.MessageBase newMessage)
        {
            PrevMessage = prevMessage;
            NewMessage = newMessage;
        }
    #nullable disable
        internal ChannelAdminLogEventActionEditMessage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(PrevMessage);
            writer.Write(NewMessage);
        }

        public override void Deserialize(Reader reader)
        {
            PrevMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            NewMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionEditMessage";
        }
    }
}