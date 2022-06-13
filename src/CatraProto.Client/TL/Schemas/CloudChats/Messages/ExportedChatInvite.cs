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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ExportedChatInvite : CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 410107472; }

        [Newtonsoft.Json.JsonProperty("invite")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ExportedChatInvite(CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Invite = invite;
            Users = users;

        }
#nullable disable
        internal ExportedChatInvite()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkinvite = writer.WriteObject(Invite);
            if (checkinvite.IsError)
            {
                return checkinvite;
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
            var tryinvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            if (tryinvite.IsError)
            {
                return ReadResult<IObject>.Move(tryinvite);
            }
            Invite = tryinvite.Value;
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
            return "messages.exportedChatInvite";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ExportedChatInvite();
            var cloneInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)Invite.Clone();
            if (cloneInvite is null)
            {
                return null;
            }
            newClonedObject.Invite = cloneInvite;
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
#nullable disable
    }
}