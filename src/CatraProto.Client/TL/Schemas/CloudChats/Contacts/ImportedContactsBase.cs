using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public abstract class ImportedContactsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("imported")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase> Imported { get; set; }

[Newtonsoft.Json.JsonProperty("popular_invites")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase> PopularInvites { get; set; }

[Newtonsoft.Json.JsonProperty("retry_contacts")]
		public abstract IList<long> RetryContacts { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
