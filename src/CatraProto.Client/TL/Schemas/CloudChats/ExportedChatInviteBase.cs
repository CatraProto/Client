using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ExportedChatInviteBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("revoked")]
        public abstract bool Revoked { get; set; }

        [Newtonsoft.Json.JsonProperty("permanent")]
        public abstract bool Permanent { get; set; }

        [Newtonsoft.Json.JsonProperty("request_needed")]
        public abstract bool RequestNeeded { get; set; }

        [Newtonsoft.Json.JsonProperty("link")]
        public abstract string Link { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public abstract long AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public abstract int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("start_date")]
        public abstract int? StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("expire_date")]
        public abstract int? ExpireDate { get; set; }

        [Newtonsoft.Json.JsonProperty("usage_limit")]
        public abstract int? UsageLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("usage")]
        public abstract int? Usage { get; set; }

        [Newtonsoft.Json.JsonProperty("requested")]
        public abstract int? Requested { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

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
