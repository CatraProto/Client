using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessageCallbackQuery : CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase
    {
        public static int StaticConstructorId
        {
            get => -1392895362;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }


    #nullable enable
        public InputMessageCallbackQuery(int id, long queryId)
        {
            Id = id;
            QueryId = queryId;
        }
    #nullable disable
        internal InputMessageCallbackQuery()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(QueryId);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<int>();
            QueryId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "inputMessageCallbackQuery";
        }
    }
}