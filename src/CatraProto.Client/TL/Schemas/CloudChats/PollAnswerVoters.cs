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
    public partial class PollAnswerVoters : CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Chosen = 1 << 0,
            Correct = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 997055186; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("chosen")]
        public sealed override bool Chosen { get; set; }

        [Newtonsoft.Json.JsonProperty("correct")]
        public sealed override bool Correct { get; set; }

        [Newtonsoft.Json.JsonProperty("option")]
        public sealed override byte[] Option { get; set; }

        [Newtonsoft.Json.JsonProperty("voters")]
        public sealed override int Voters { get; set; }


#nullable enable
        public PollAnswerVoters(byte[] option, int voters)
        {
            Option = option;
            Voters = voters;
        }
#nullable disable
        internal PollAnswerVoters()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Chosen ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Correct ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteBytes(Option);
            writer.WriteInt32(Voters);

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
            Correct = FlagsHelper.IsFlagSet(Flags, 1);
            var tryoption = reader.ReadBytes();
            if (tryoption.IsError)
            {
                return ReadResult<IObject>.Move(tryoption);
            }

            Option = tryoption.Value;
            var tryvoters = reader.ReadInt32();
            if (tryvoters.IsError)
            {
                return ReadResult<IObject>.Move(tryvoters);
            }

            Voters = tryvoters.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pollAnswerVoters";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PollAnswerVoters();
            newClonedObject.Flags = Flags;
            newClonedObject.Chosen = Chosen;
            newClonedObject.Correct = Correct;
            newClonedObject.Option = Option;
            newClonedObject.Voters = Voters;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PollAnswerVoters castedOther)
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

            if (Correct != castedOther.Correct)
            {
                return true;
            }

            if (Option != castedOther.Option)
            {
                return true;
            }

            if (Voters != castedOther.Voters)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}