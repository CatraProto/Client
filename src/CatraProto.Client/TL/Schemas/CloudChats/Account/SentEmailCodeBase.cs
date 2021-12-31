using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class SentEmailCodeBase : IObject
    {

[Newtonsoft.Json.JsonProperty("email_pattern")]
		public abstract string EmailPattern { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public abstract int Length { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
