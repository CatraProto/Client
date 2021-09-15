using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public abstract class ImportedContactsBase : IObject
    {
        [JsonProperty("imported")] public abstract IList<ImportedContactBase> Imported { get; set; }

        [JsonProperty("popular_invites")] public abstract IList<PopularContactBase> PopularInvites { get; set; }

        [JsonProperty("retry_contacts")] public abstract IList<long> RetryContacts { get; set; }

        [JsonProperty("users")] public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}