using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SearchResultsPositionBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public abstract int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public abstract int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public abstract int Offset { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
