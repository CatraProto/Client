using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PeerSettingsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("report_spam")]
        public abstract bool ReportSpam { get; set; }

        [Newtonsoft.Json.JsonProperty("add_contact")]
        public abstract bool AddContact { get; set; }

        [Newtonsoft.Json.JsonProperty("block_contact")]
        public abstract bool BlockContact { get; set; }

        [Newtonsoft.Json.JsonProperty("share_contact")]
        public abstract bool ShareContact { get; set; }

        [Newtonsoft.Json.JsonProperty("need_contacts_exception")]
        public abstract bool NeedContactsException { get; set; }

        [Newtonsoft.Json.JsonProperty("report_geo")]
        public abstract bool ReportGeo { get; set; }

        [Newtonsoft.Json.JsonProperty("autoarchived")]
        public abstract bool Autoarchived { get; set; }

        [Newtonsoft.Json.JsonProperty("invite_members")]
        public abstract bool InviteMembers { get; set; }

        [Newtonsoft.Json.JsonProperty("request_chat_broadcast")]
        public abstract bool RequestChatBroadcast { get; set; }

        [Newtonsoft.Json.JsonProperty("geo_distance")]
        public abstract int? GeoDistance { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("request_chat_title")]
        public abstract string RequestChatTitle { get; set; }

        [Newtonsoft.Json.JsonProperty("request_chat_date")]
        public abstract int? RequestChatDate { get; set; }

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