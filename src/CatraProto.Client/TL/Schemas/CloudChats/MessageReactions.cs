using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1328256121; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("min")] public sealed override bool Min { get; set; }

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
            var newClonedObject = new MessageReactions();
            newClonedObject.Flags = Flags;
            newClonedObject.Min = Min;
            newClonedObject.CanSeeList = CanSeeList;
            newClonedObject.Results = new List<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase>();
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

        public override bool Compare(IObject other)
        {
            if (other is not MessageReactions castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Min != castedOther.Min)
            {
                return true;
            }

            if (CanSeeList != castedOther.CanSeeList)
            {
                return true;
            }

            var resultssize = castedOther.Results.Count;
            if (resultssize != Results.Count)
            {
                return true;
            }

            for (var i = 0; i < resultssize; i++)
            {
                if (castedOther.Results[i].Compare(Results[i]))
                {
                    return true;
                }
            }

            if (RecentReactions is null && castedOther.RecentReactions is not null || RecentReactions is not null && castedOther.RecentReactions is null)
            {
                return true;
            }

            if (RecentReactions is not null && castedOther.RecentReactions is not null)
            {
                var recentReactionssize = castedOther.RecentReactions.Count;
                if (recentReactionssize != RecentReactions.Count)
                {
                    return true;
                }

                for (var i = 0; i < recentReactionssize; i++)
                {
                    if (castedOther.RecentReactions[i].Compare(RecentReactions[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

#nullable disable
    }
}