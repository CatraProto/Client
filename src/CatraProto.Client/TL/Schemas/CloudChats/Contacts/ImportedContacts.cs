using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public class ImportedContacts : ImportedContactsBase
    {
        public static int ConstructorId { get; } = 2010127419;
        public override IList<ImportedContactBase> Imported { get; set; }
        public override IList<PopularContactBase> PopularInvites { get; set; }
        public override IList<long> RetryContacts { get; set; }
        public override IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Imported);
            writer.Write(PopularInvites);
            writer.Write(RetryContacts);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Imported = reader.ReadVector<ImportedContactBase>();
            PopularInvites = reader.ReadVector<PopularContactBase>();
            RetryContacts = reader.ReadVector<long>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}