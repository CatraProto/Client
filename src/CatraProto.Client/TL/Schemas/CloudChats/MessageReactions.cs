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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageReactions : CatraProto.Client.TL.Schemas.CloudChats.MessageReactionsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Min = 1 << 0,
            CanSeeList = 1 << 2,
            RecentReactions = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1328256121; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("min")]
        public sealed override bool Min { get; set; }

        [Newtonsoft.Json.JsonProperty("can_see_list")]
        public sealed override bool CanSeeList { get; set; }

        [Newtonsoft.Json.JsonProperty("results")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase> Results { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("recent_reactions")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase> RecentReactions { get; set; }


#nullable enable
        public MessageReactions(List<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase> results)
        {
            Results = results;

        }
#nullable disable
        internal MessageReactions()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Min ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = CanSeeList ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = RecentReactions == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkresults = writer.WriteVector(Results, false);
            if (checkresults.IsError)
            {
                return checkresults;
            }
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkrecentReactions = writer.WriteVector(RecentReactions, false);
                if (checkrecentReactions.IsError)
                {
                    return checkrecentReactions;
                }
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
            Min = FlagsHelper.IsFlagSet(Flags, 0);
            CanSeeList = FlagsHelper.IsFlagSet(Flags, 2);
            var tryresults = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryresults.IsError)
            {
                return ReadResult<IObject>.Move(tryresults);
            }
            Results = tryresults.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryrecentReactions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryrecentReactions.IsError)
                {
                    return ReadResult<IObject>.Move(tryrecentReactions);
                }
                RecentReactions = tryrecentReactions.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageReactions";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageReactions
            {
                Flags = Flags,
                Min = Min,
                CanSeeList = CanSeeList,
                Results = new List<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase>()
            };
            foreach (var results in Results)
            {
                var cloneresults = (CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase?)results.Clone();
                if (cloneresults is null)
                {
                    return null;
                }
                newClonedObject.Results.Add(cloneresults);
            }
            if (RecentReactions is not null)
            {
                newClonedObject.RecentReactions = new List<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase>();
                foreach (var recentReactions in RecentReactions)
                {
                    var clonerecentReactions = (CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase?)recentReactions.Clone();
                    if (clonerecentReactions is null)
                    {
                        return null;
                    }
                    newClonedObject.RecentReactions.Add(clonerecentReactions);
                }
            }
            return newClonedObject;

        }
#nullable disable
    }
}