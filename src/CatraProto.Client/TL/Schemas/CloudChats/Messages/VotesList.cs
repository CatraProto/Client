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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class VotesList : CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NextOffset = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 136574537; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("votes")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase> Votes { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("next_offset")]
        public sealed override string NextOffset { get; set; }


#nullable enable
        public VotesList(int count, List<CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase> votes, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            Votes = votes;
            Users = users;

        }
#nullable disable
        internal VotesList()
        {
        }

        public override void UpdateFlags()
        {
            Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Count);
            var checkvotes = writer.WriteVector(Votes, false);
            if (checkvotes.IsError)
            {
                return checkvotes;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteString(NextOffset);
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }
            Count = trycount.Value;
            var tryvotes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryvotes.IsError)
            {
                return ReadResult<IObject>.Move(tryvotes);
            }
            Votes = tryvotes.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trynextOffset = reader.ReadString();
                if (trynextOffset.IsError)
                {
                    return ReadResult<IObject>.Move(trynextOffset);
                }
                NextOffset = trynextOffset.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.votesList";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new VotesList
            {
                Flags = Flags,
                Count = Count,
                Votes = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase>()
            };
            foreach (var votes in Votes)
            {
                var clonevotes = (CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase?)votes.Clone();
                if (clonevotes is null)
                {
                    return null;
                }
                newClonedObject.Votes.Add(clonevotes);
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
            newClonedObject.NextOffset = NextOffset;
            return newClonedObject;

        }
#nullable disable
    }
}