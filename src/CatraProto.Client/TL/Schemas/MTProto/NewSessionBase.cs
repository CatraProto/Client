using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class NewSessionBase : IObject
    {

[Newtonsoft.Json.JsonProperty("first_msg_id")]
		public abstract long FirstMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("unique_id")]
		public abstract long UniqueId { get; set; }

[Newtonsoft.Json.JsonProperty("server_salt")]
		public abstract long ServerSalt { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
