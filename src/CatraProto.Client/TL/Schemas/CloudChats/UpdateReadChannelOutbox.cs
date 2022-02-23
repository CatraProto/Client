using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateReadChannelOutbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -1218471511;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }


    #nullable enable
        public UpdateReadChannelOutbox(long channelId, int maxId)
        {
            ChannelId = channelId;
            MaxId = maxId;
        }
    #nullable disable
        internal UpdateReadChannelOutbox()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChannelId);
            writer.Write(MaxId);
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<long>();
            MaxId = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateReadChannelOutbox";
        }
    }
}