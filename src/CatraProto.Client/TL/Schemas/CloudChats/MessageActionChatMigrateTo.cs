using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionChatMigrateTo : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -519864430;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }


    #nullable enable
        public MessageActionChatMigrateTo(long channelId)
        {
            ChannelId = channelId;
        }
    #nullable disable
        internal MessageActionChatMigrateTo()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChannelId);
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "messageActionChatMigrateTo";
        }
    }
}