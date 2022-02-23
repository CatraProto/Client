using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class TermsOfServiceBase : IObject
    {

[Newtonsoft.Json.JsonProperty("popup")]
		public abstract bool Popup { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Id { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public abstract string Text { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[Newtonsoft.Json.JsonProperty("min_age_confirm")]
		public abstract int? MinAgeConfirm { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
