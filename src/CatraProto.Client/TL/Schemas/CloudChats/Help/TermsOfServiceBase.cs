using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class TermsOfServiceBase : IObject
    {

[JsonPropertyName("popup")]
		public abstract bool Popup { get; set; }

[JsonPropertyName("id")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Id { get; set; }

[JsonPropertyName("text")]
		public abstract string Text { get; set; }

[JsonPropertyName("entities")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[JsonPropertyName("min_age_confirm")]
		public abstract int? MinAgeConfirm { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
