using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public abstract class ImportedContactsBase : IObject
    {
		public abstract IList<ImportedContactBase> Imported { get; set; }
		public abstract IList<PopularContactBase> PopularInvites { get; set; }
		public abstract IList<long> RetryContacts { get; set; }
		public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
