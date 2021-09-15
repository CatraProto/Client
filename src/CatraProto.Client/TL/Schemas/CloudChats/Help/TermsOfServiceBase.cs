using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class TermsOfServiceBase : IObject
    {
        [JsonProperty("popup")] public abstract bool Popup { get; set; }

        [JsonProperty("id")] public abstract DataJSONBase Id { get; set; }

        [JsonProperty("text")] public abstract string Text { get; set; }

        [JsonProperty("entities")] public abstract IList<MessageEntityBase> Entities { get; set; }

        [JsonProperty("min_age_confirm")] public abstract int? MinAgeConfirm { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}