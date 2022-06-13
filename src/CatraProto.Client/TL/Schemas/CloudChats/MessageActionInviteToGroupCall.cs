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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionInviteToGroupCall : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1345295095; }

        [Newtonsoft.Json.JsonProperty("call")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<long> Users { get; set; }


#nullable enable
        public MessageActionInviteToGroupCall(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, List<long> users)
        {
            Call = call;
            Users = users;

        }
#nullable disable
        internal MessageActionInviteToGroupCall()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }

            writer.WriteVector(Users, false);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }
            Call = trycall.Value;
            var tryusers = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageActionInviteToGroupCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionInviteToGroupCall();
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }
            newClonedObject.Call = cloneCall;
            newClonedObject.Users = new List<long>();
            foreach (var users in Users)
            {
                newClonedObject.Users.Add(users);
            }
            return newClonedObject;

        }
#nullable disable
    }
}