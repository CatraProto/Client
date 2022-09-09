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
    public partial class ReactionCount : CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Chosen = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1873957073; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("chosen")]
        public sealed override bool Chosen { get; set; }

        [Newtonsoft.Json.JsonProperty("reaction")]
        public sealed override string Reaction { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }


#nullable enable
        public ReactionCount(string reaction, int count)
        {
            Reaction = reaction;
            Count = count;
        }
#nullable disable
        internal ReactionCount()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Chosen ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Reaction);
            writer.WriteInt32(Count);

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
            Chosen = FlagsHelper.IsFlagSet(Flags, 0);
            var tryreaction = reader.ReadString();
            if (tryreaction.IsError)
            {
                return ReadResult<IObject>.Move(tryreaction);
            }

            Reaction = tryreaction.Value;
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "reactionCount";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ReactionCount();
            newClonedObject.Flags = Flags;
            newClonedObject.Chosen = Chosen;
            newClonedObject.Reaction = Reaction;
            newClonedObject.Count = Count;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ReactionCount castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Chosen != castedOther.Chosen)
            {
                return true;
            }

            if (Reaction != castedOther.Reaction)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}