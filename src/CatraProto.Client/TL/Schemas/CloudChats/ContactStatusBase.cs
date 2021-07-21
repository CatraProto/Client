using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ContactStatusBase : IObject
    {

[JsonPropertyName("user_id")]
		public abstract int UserId { get; set; }

[JsonPropertyName("status")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase Status { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
