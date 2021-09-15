using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ImportedContacts : ImportedContactsBase
    {
        public static int StaticConstructorId
        {
            get => 2010127419;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("imported")] public override IList<ImportedContactBase> Imported { get; set; }

        [JsonProperty("popular_invites")] public override IList<PopularContactBase> PopularInvites { get; set; }

        [JsonProperty("retry_contacts")] public override IList<long> RetryContacts { get; set; }

        [JsonProperty("users")] public override IList<UserBase> Users { get; set; }


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

        public override string ToString()
        {
            return "contacts.importedContacts";
        }
    }
}