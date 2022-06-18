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
    public partial class Blocked : CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockedBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 182326673; }

        [Newtonsoft.Json.JsonProperty("blocked")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase> BlockedField { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public Blocked(List<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase> blockedField, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            BlockedField = blockedField;
            Chats = chats;
            Users = users;

        }
#nullable disable
        internal Blocked()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkblockedField = writer.WriteVector(BlockedField, false);
            if (checkblockedField.IsError)
            {
                return checkblockedField;
            }
            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryblockedField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryblockedField.IsError)
            {
                return ReadResult<IObject>.Move(tryblockedField);
            }
            BlockedField = tryblockedField.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }
            Chats = trychats.Value;
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
            return "contacts.blocked";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Blocked
            {
                BlockedField = new List<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase>()
            };
            foreach (var blockedField in BlockedField)
            {
                var cloneblockedField = (CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase?)blockedField.Clone();
                if (cloneblockedField is null)
                {
                    return null;
                }
                newClonedObject.BlockedField.Add(cloneblockedField);
            }
            newClonedObject.Chats = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            foreach (var chats in Chats)
            {
                var clonechats = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chats.Clone();
                if (clonechats is null)
                {
                    return null;
                }
                newClonedObject.Chats.Add(clonechats);
            }
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
            if (other is not Blocked castedOther)
            {
                return true;
            }
            var blockedFieldsize = castedOther.BlockedField.Count;
            if (blockedFieldsize != BlockedField.Count)
            {
                return true;
            }
            for (var i = 0; i < blockedFieldsize; i++)
            {
                if (castedOther.BlockedField[i].Compare(BlockedField[i]))
                {
                    return true;
                }
            }
            var chatssize = castedOther.Chats.Count;
            if (chatssize != Chats.Count)
            {
                return true;
            }
            for (var i = 0; i < chatssize; i++)
            {
                if (castedOther.Chats[i].Compare(Chats[i]))
                {
                    return true;
                }
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