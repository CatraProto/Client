/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ApiContacts
            {
                Contacts = new List<CatraProto.Client.TL.Schemas.CloudChats.ContactBase>()
            };
            foreach (var contacts in Contacts)
            {
                var clonecontacts = (CatraProto.Client.TL.Schemas.CloudChats.ContactBase?)contacts.Clone();
                if (clonecontacts is null)
                {
                    return null;
                }
                newClonedObject.Contacts.Add(clonecontacts);
            }
            newClonedObject.SavedCount = SavedCount;
            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
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

        public override bool Compare(IObject other)
        {
            if (other is not ApiContacts castedOther)
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
            if (SavedCount != castedOther.SavedCount)
            {
                return true;
            }
            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }
            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}