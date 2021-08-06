using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputSingleMediaBase : IObject
    {

[JsonPropertyName("media")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

[JsonPropertyName("random_id")]
		public abstract long RandomId { get; set; }

[JsonPropertyName("message")]
		public abstract string Message { get; set; }

[JsonPropertyName("entities")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
