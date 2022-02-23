using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDeleteChannelMessages : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -1020437742;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public IList<int> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


    #nullable enable
        public UpdateDeleteChannelMessages(long channelId, IList<int> messages, int pts, int ptsCount)
        {
            ChannelId = channelId;
            Messages = messages;
            Pts = pts;
            PtsCount = ptsCount;
        }
    #nullable disable
        internal UpdateDeleteChannelMessages()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChannelId);
            writer.Write(Messages);
            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<long>();
            Messages = reader.ReadVector<int>();
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateDeleteChannelMessages";
        }
    }
}