using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class TmpPasswordBase : IObject
    {

[Newtonsoft.Json.JsonProperty("tmp_password")]
		public abstract byte[] TmpPasswordField { get; set; }

[Newtonsoft.Json.JsonProperty("valid_until")]
		public abstract int ValidUntil { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
