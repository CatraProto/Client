using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class PremiumPromoBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("status_text")]
        public abstract string StatusText { get; set; }

        [Newtonsoft.Json.JsonProperty("status_entities")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> StatusEntities { get; set; }

        [Newtonsoft.Json.JsonProperty("video_sections")]
        public abstract List<string> VideoSections { get; set; }

        [Newtonsoft.Json.JsonProperty("videos")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Videos { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public abstract string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("monthly_amount")]
        public abstract long MonthlyAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

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