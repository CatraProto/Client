using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class TermsOfServiceBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("popup")]
        public abstract bool Popup { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public abstract CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public abstract string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("entities")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        [Newtonsoft.Json.JsonProperty("min_age_confirm")]
        public abstract int? MinAgeConfirm { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}