using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsGroupTopPoster : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase
    {
        public static int StaticConstructorId
        {
            get => -1660637285;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override int Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("avg_chars")]
        public sealed override int AvgChars { get; set; }


    #nullable enable
        public StatsGroupTopPoster(long userId, int messages, int avgChars)
        {
            UserId = userId;
            Messages = messages;
            AvgChars = avgChars;
        }
    #nullable disable
        internal StatsGroupTopPoster()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(Messages);
            writer.Write(AvgChars);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<long>();
            Messages = reader.Read<int>();
            AvgChars = reader.Read<int>();
        }

        public override string ToString()
        {
            return "statsGroupTopPoster";
        }
    }
}