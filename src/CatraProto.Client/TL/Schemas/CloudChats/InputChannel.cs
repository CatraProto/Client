using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputChannel : CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase
    {
        public static int StaticConstructorId
        {
            get => -212145112;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }


    #nullable enable
        public InputChannel(long channelId, long accessHash)
        {
            ChannelId = channelId;
            AccessHash = accessHash;
        }
    #nullable disable
        internal InputChannel()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChannelId);
            writer.Write(AccessHash);
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<long>();
            AccessHash = reader.Read<long>();
        }

        public override string ToString()
        {
            return "inputChannel";
        }
    }
}