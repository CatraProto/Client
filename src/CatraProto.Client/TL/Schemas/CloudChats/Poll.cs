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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2032041631; }

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
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase> Answers { get; set; }

        [Newtonsoft.Json.JsonProperty("close_period")]
        public sealed override int? ClosePeriod { get; set; }

        [Newtonsoft.Json.JsonProperty("close_date")]
        public sealed override int? CloseDate { get; set; }


#nullable enable
        public Poll(long id, string question, List<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase> answers)
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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Question);
            var checkanswers = writer.WriteVector(Answers, false);
            if (checkanswers.IsError)
            {
                return checkanswers;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(ClosePeriod.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteInt32(CloseDate.Value);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Closed = FlagsHelper.IsFlagSet(Flags, 0);
            PublicVoters = FlagsHelper.IsFlagSet(Flags, 1);
            MultipleChoice = FlagsHelper.IsFlagSet(Flags, 2);
            Quiz = FlagsHelper.IsFlagSet(Flags, 3);
            var tryquestion = reader.ReadString();
            if (tryquestion.IsError)
            {
                return ReadResult<IObject>.Move(tryquestion);
            }

            Question = tryquestion.Value;
            var tryanswers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryanswers.IsError)
            {
                return ReadResult<IObject>.Move(tryanswers);
            }

            Answers = tryanswers.Value;
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryclosePeriod = reader.ReadInt32();
                if (tryclosePeriod.IsError)
                {
                    return ReadResult<IObject>.Move(tryclosePeriod);
                }

                ClosePeriod = tryclosePeriod.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var trycloseDate = reader.ReadInt32();
                if (trycloseDate.IsError)
                {
                    return ReadResult<IObject>.Move(trycloseDate);
                }

                CloseDate = trycloseDate.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "poll";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Poll();
            newClonedObject.Id = Id;
            newClonedObject.Flags = Flags;
            newClonedObject.Closed = Closed;
            newClonedObject.PublicVoters = PublicVoters;
            newClonedObject.MultipleChoice = MultipleChoice;
            newClonedObject.Quiz = Quiz;
            newClonedObject.Question = Question;
            newClonedObject.Answers = new List<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase>();
            foreach (var answers in Answers)
            {
                var cloneanswers = (CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase?)answers.Clone();
                if (cloneanswers is null)
                {
                    return null;
                }

                newClonedObject.Answers.Add(cloneanswers);
            }

            newClonedObject.ClosePeriod = ClosePeriod;
            newClonedObject.CloseDate = CloseDate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Poll castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Closed != castedOther.Closed)
            {
                return true;
            }

            if (PublicVoters != castedOther.PublicVoters)
            {
                return true;
            }

            if (MultipleChoice != castedOther.MultipleChoice)
            {
                return true;
            }

            if (Quiz != castedOther.Quiz)
            {
                return true;
            }

            if (Question != castedOther.Question)
            {
                return true;
            }

            var answerssize = castedOther.Answers.Count;
            if (answerssize != Answers.Count)
            {
                return true;
            }

            for (var i = 0; i < answerssize; i++)
            {
                if (castedOther.Answers[i].Compare(Answers[i]))
                {
                    return true;
                }
            }

            if (ClosePeriod != castedOther.ClosePeriod)
            {
                return true;
            }

            if (CloseDate != castedOther.CloseDate)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}