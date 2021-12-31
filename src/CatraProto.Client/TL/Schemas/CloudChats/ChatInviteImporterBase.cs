using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatInviteImporterBase : IObject
    {

[Newtonsoft.Json.JsonProperty("requested")]
		public abstract bool Requested { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public abstract long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public abstract int Date { get; set; }

[Newtonsoft.Json.JsonProperty("about")]
		public abstract string About { get; set; }

[Newtonsoft.Json.JsonProperty("approved_by")]
		public abstract long? ApprovedBy { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
