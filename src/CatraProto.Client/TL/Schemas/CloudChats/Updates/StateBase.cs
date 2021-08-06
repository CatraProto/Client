using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public abstract class StateBase : IObject
    {

[JsonPropertyName("pts")]
		public abstract int Pts { get; set; }

[JsonPropertyName("qts")]
		public abstract int Qts { get; set; }

[JsonPropertyName("date")]
		public abstract int Date { get; set; }

[JsonPropertyName("seq")]
		public abstract int Seq { get; set; }

[JsonPropertyName("unread_count")]
		public abstract int UnreadCount { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
