using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class AffectedMessagesBase : IObject
    {

[JsonPropertyName("pts")]
		public abstract int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public abstract int PtsCount { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
