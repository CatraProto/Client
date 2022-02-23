using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageRange : CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase
    {
        public static int StaticConstructorId
        {
            get => 182649427;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("min_id")]
        public sealed override int MinId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public sealed override int MaxId { get; set; }


    #nullable enable
        public MessageRange(int minId, int maxId)
        {
            MinId = minId;
            MaxId = maxId;
        }
    #nullable disable
        internal MessageRange()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(MinId);
            writer.Write(MaxId);
        }

        public override void Deserialize(Reader reader)
        {
            MinId = reader.Read<int>();
            MaxId = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messageRange";
        }
    }
}