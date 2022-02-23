using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetSearchResultsCalendar : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1240514025;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendarBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("filter")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id")]
        public int OffsetId { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_date")]
        public int OffsetDate { get; set; }


    #nullable enable
        public GetSearchResultsCalendar(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int offsetId, int offsetDate)
        {
            Peer = peer;
            Filter = filter;
            OffsetId = offsetId;
            OffsetDate = offsetDate;
        }
    #nullable disable

        internal GetSearchResultsCalendar()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(Filter);
            writer.Write(OffsetId);
            writer.Write(OffsetDate);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
            OffsetId = reader.Read<int>();
            OffsetDate = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messages.getSearchResultsCalendar";
        }
    }
}