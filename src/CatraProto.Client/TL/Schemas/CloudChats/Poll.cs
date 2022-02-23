using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Poll : CatraProto.Client.TL.Schemas.CloudChats.PollBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Closed = 1 << 0,
            PublicVoters = 1 << 1,
            MultipleChoice = 1 << 2,
            Quiz = 1 << 3,
            ClosePeriod = 1 << 4,
            CloseDate = 1 << 5
        }

        public static int StaticConstructorId
        {
            get => -2032041631;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("closed")]
        public sealed override bool Closed { get; set; }

        [Newtonsoft.Json.JsonProperty("public_voters")]
        public sealed override bool PublicVoters { get; set; }

        [Newtonsoft.Json.JsonProperty("multiple_choice")]
        public sealed override bool MultipleChoice { get; set; }

        [Newtonsoft.Json.JsonProperty("quiz")] public sealed override bool Quiz { get; set; }

        [Newtonsoft.Json.JsonProperty("question")]
        public sealed override string Question { get; set; }

        [Newtonsoft.Json.JsonProperty("answers")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase> Answers { get; set; }

        [Newtonsoft.Json.JsonProperty("close_period")]
        public sealed override int? ClosePeriod { get; set; }

        [Newtonsoft.Json.JsonProperty("close_date")]
        public sealed override int? CloseDate { get; set; }


    #nullable enable
        public Poll(long id, string question, IList<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase> answers)
        {
            Id = id;
            Question = question;
            Answers = answers;
        }
    #nullable disable
        internal Poll()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Closed ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = PublicVoters ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = MultipleChoice ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Quiz ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = ClosePeriod == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = CloseDate == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Question);
            writer.Write(Answers);
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(ClosePeriod.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.Write(CloseDate.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            Flags = reader.Read<int>();
            Closed = FlagsHelper.IsFlagSet(Flags, 0);
            PublicVoters = FlagsHelper.IsFlagSet(Flags, 1);
            MultipleChoice = FlagsHelper.IsFlagSet(Flags, 2);
            Quiz = FlagsHelper.IsFlagSet(Flags, 3);
            Question = reader.Read<string>();
            Answers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase>();
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                ClosePeriod = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                CloseDate = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "poll";
        }
    }
}