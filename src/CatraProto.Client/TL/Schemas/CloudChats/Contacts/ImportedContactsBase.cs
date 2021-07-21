using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public abstract class ImportedContactsBase : IObject
    {

[JsonPropertyName("imported")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase> Imported { get; set; }

[JsonPropertyName("popular_invites")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase> PopularInvites { get; set; }

[JsonPropertyName("retry_contacts")]
		public abstract IList<long> RetryContacts { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
