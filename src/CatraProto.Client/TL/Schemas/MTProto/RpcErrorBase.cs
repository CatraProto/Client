using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class RpcErrorBase : IObject
    {

[Newtonsoft.Json.JsonProperty("error_code")]
		public abstract int ErrorCode { get; set; }

[Newtonsoft.Json.JsonProperty("error_message")]
		public abstract string ErrorMessage { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
