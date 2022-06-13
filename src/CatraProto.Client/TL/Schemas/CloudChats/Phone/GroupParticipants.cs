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
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class GroupParticipants : CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipantsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -193506890; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> Participants { get; set; }

        [Newtonsoft.Json.JsonProperty("next_offset")]
        public sealed override string NextOffset { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public sealed override int Version { get; set; }


#nullable enable
        public GroupParticipants(int count, List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> participants, string nextOffset, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users, int version)
        {
            Count = count;
            Participants = participants;
            NextOffset = nextOffset;
            Chats = chats;
            Users = users;
            Version = version;

        }
#nullable disable
        internal GroupParticipants()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);
            var checkparticipants = writer.WriteVector(Participants, false);
            if (checkparticipants.IsError)
            {
                return checkparticipants;
            }

            writer.WriteString(NextOffset);
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
            writer.WriteInt32(Version);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }
            Count = trycount.Value;
            var tryparticipants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryparticipants.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipants);
            }
            Participants = tryparticipants.Value;
            var trynextOffset = reader.ReadString();
            if (trynextOffset.IsError)
            {
                return ReadResult<IObject>.Move(trynextOffset);
            }
            NextOffset = trynextOffset.Value;
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
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }
            Version = tryversion.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.groupParticipants";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupParticipants
            {
                Count = Count,
                Participants = new List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>()
            };
            foreach (var participants in Participants)
            {
                var cloneparticipants = (CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase?)participants.Clone();
                if (cloneparticipants is null)
                {
                    return null;
                }
                newClonedObject.Participants.Add(cloneparticipants);
            }
            newClonedObject.NextOffset = NextOffset;
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
            newClonedObject.Version = Version;
            return newClonedObject;

        }
#nullable disable
    }
}