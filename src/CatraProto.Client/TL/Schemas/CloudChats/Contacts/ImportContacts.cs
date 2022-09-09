using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ImportContacts : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 746589157; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("contacts")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase> Contacts { get; set; }


#nullable enable
        public ImportContacts(List<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase> contacts)
        {
            Contacts = contacts;
        }
#nullable disable

        internal ImportContacts()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcontacts = writer.WriteVector(Contacts, false);
            if (checkcontacts.IsError)
            {
                return checkcontacts;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycontacts = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycontacts.IsError)
            {
                return ReadResult<IObject>.Move(trycontacts);
            }

            Contacts = trycontacts.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contacts.importContacts";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ImportContacts();
            newClonedObject.Contacts = new List<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase>();
            foreach (var contacts in Contacts)
            {
                var clonecontacts = (CatraProto.Client.TL.Schemas.CloudChats.InputContactBase?)contacts.Clone();
                if (clonecontacts is null)
                {
                    return null;
                }

                newClonedObject.Contacts.Add(clonecontacts);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ImportContacts castedOther)
            {
                return true;
            }

            var contactssize = castedOther.Contacts.Count;
            if (contactssize != Contacts.Count)
            {
                return true;
            }

            for (var i = 0; i < contactssize; i++)
            {
                if (castedOther.Contacts[i].Compare(Contacts[i]))
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}