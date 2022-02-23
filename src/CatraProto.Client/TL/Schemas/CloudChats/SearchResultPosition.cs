using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SearchResultPosition : CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase
    {
        public static int StaticConstructorId
        {
            get => 2137295719;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }


    #nullable enable
        public SearchResultPosition(int msgId, int date, int offset)
        {
            MsgId = msgId;
            Date = date;
            Offset = offset;
        }
    #nullable disable
        internal SearchResultPosition()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(MsgId);
            writer.Write(Date);
            writer.Write(Offset);
        }

        public override void Deserialize(Reader reader)
        {
            MsgId = reader.Read<int>();
            Date = reader.Read<int>();
            Offset = reader.Read<int>();
        }

        public override string ToString()
        {
            return "searchResultPosition";
        }
    }
}