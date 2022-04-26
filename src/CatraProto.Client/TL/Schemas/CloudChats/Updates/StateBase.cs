using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public abstract class StateBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("pts")]
        public abstract int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")]
        public abstract int Qts { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public abstract int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("seq")]
        public abstract int Seq { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_count")]
        public abstract int UnreadCount { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
