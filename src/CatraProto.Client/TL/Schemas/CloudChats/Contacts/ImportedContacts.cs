using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ImportedContacts : CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportedContactsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2010127419; }

        [Newtonsoft.Json.JsonProperty("imported")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase> Imported { get; set; }

        [Newtonsoft.Json.JsonProperty("popular_invites")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase> PopularInvites { get; set; }

        [Newtonsoft.Json.JsonProperty("retry_contacts")]
        public sealed override List<long> RetryContacts { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ImportedContacts(List<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase> imported, List<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase> popularInvites, List<long> retryContacts, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Imported = imported;
            PopularInvites = popularInvites;
            RetryContacts = retryContacts;
            Users = users;

        }
#nullable disable
        internal ImportedContacts()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkimported = writer.WriteVector(Imported, false);
            if (checkimported.IsError)
            {
                return checkimported;
            }
            var checkpopularInvites = writer.WriteVector(PopularInvites, false);
            if (checkpopularInvites.IsError)
            {
                return checkpopularInvites;
            }

            writer.WriteVector(RetryContacts, false);
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryimported = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryimported.IsError)
            {
                return ReadResult<IObject>.Move(tryimported);
            }
            Imported = tryimported.Value;
            var trypopularInvites = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypopularInvites.IsError)
            {
                return ReadResult<IObject>.Move(trypopularInvites);
            }
            PopularInvites = trypopularInvites.Value;
            var tryretryContacts = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryretryContacts.IsError)
            {
                return ReadResult<IObject>.Move(tryretryContacts);
            }
            RetryContacts = tryretryContacts.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "contacts.importedContacts";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ImportedContacts();
            foreach (var imported in Imported)
            {
                var cloneimported = (CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase?)imported.Clone();
                if (cloneimported is null)
                {
                    return null;
                }
                newClonedObject.Imported.Add(cloneimported);
            }
            foreach (var popularInvites in PopularInvites)
            {
                var clonepopularInvites = (CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase?)popularInvites.Clone();
                if (clonepopularInvites is null)
                {
                    return null;
                }
                newClonedObject.PopularInvites.Add(clonepopularInvites);
            }
            foreach (var retryContacts in RetryContacts)
            {
                newClonedObject.RetryContacts.Add(retryContacts);
            }
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }
                newClonedObject.Users.Add(cloneusers);
            }
            return newClonedObject;

        }
#nullable disable
    }
}