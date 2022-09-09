using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public abstract class ImportedContactsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("imported")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase> Imported { get; set; }

        [Newtonsoft.Json.JsonProperty("popular_invites")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase> PopularInvites { get; set; }

        [Newtonsoft.Json.JsonProperty("retry_contacts")]
        public abstract List<long> RetryContacts { get; set; }

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