using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ApiContacts : CatraProto.Client.TL.Schemas.CloudChats.Contacts.ContactsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -353862078; }

        [Newtonsoft.Json.JsonProperty("contacts")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ContactBase> Contacts { get; set; }

        [Newtonsoft.Json.JsonProperty("saved_count")]
        public int SavedCount { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ApiContacts(List<CatraProto.Client.TL.Schemas.CloudChats.ContactBase> contacts, int savedCount, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Contacts = contacts;
            SavedCount = savedCount;
            Users = users;

        }
#nullable disable
        internal ApiContacts()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcontacts = writer.WriteVector(Contacts, false);
            if (checkcontacts.IsError)
            {
                return checkcontacts;
            }
            writer.WriteInt32(SavedCount);
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycontacts = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ContactBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycontacts.IsError)
            {
                return ReadResult<IObject>.Move(trycontacts);
            }
            Contacts = trycontacts.Value;
            var trysavedCount = reader.ReadInt32();
            if (trysavedCount.IsError)
            {
                return ReadResult<IObject>.Move(trysavedCount);
            }
            SavedCount = trysavedCount.Value;
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
            return "contacts.contacts";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}