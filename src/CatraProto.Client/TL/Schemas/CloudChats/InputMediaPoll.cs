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
    public partial class InputMediaPoll : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CorrectAnswers = 1 << 0,
            Solution = 1 << 1,
            SolutionEntities = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 261416433; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("poll")] public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }

        [Newtonsoft.Json.JsonProperty("correct_answers")]
        public List<byte[]> CorrectAnswers { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("solution")]
        public string Solution { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("solution_entities")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> SolutionEntities { get; set; }


#nullable enable
        public InputMediaPoll(CatraProto.Client.TL.Schemas.CloudChats.PollBase poll)
        {
            Poll = poll;
        }
#nullable disable
        internal InputMediaPoll()
        {
        }

        public override void UpdateFlags()
        {
            Flags = CorrectAnswers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Solution == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = SolutionEntities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpoll = writer.WriteObject(Poll);
            if (checkpoll.IsError)
            {
                return checkpoll;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteVector(CorrectAnswers, false);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Solution);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checksolutionEntities = writer.WriteVector(SolutionEntities, false);
                if (checksolutionEntities.IsError)
                {
                    return checksolutionEntities;
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
            var trypoll = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
            if (trypoll.IsError)
            {
                return ReadResult<IObject>.Move(trypoll);
            }

            Poll = trypoll.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trycorrectAnswers = reader.ReadVector<byte[]>(ParserTypes.Bytes, nakedVector: false, nakedObjects: false);
                if (trycorrectAnswers.IsError)
                {
                    return ReadResult<IObject>.Move(trycorrectAnswers);
                }

                CorrectAnswers = trycorrectAnswers.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trysolution = reader.ReadString();
                if (trysolution.IsError)
                {
                    return ReadResult<IObject>.Move(trysolution);
                }

                Solution = trysolution.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trysolutionEntities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trysolutionEntities.IsError)
                {
                    return ReadResult<IObject>.Move(trysolutionEntities);
                }

                SolutionEntities = trysolutionEntities.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputMediaPoll";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMediaPoll();
            newClonedObject.Flags = Flags;
            var clonePoll = (CatraProto.Client.TL.Schemas.CloudChats.PollBase?)Poll.Clone();
            if (clonePoll is null)
            {
                return null;
            }

            newClonedObject.Poll = clonePoll;
            if (CorrectAnswers is not null)
            {
                newClonedObject.CorrectAnswers = new List<byte[]>();
                foreach (var correctAnswers in CorrectAnswers)
                {
                    newClonedObject.CorrectAnswers.Add(correctAnswers);
                }
            }

            newClonedObject.Solution = Solution;
            if (SolutionEntities is not null)
            {
                newClonedObject.SolutionEntities = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
                foreach (var solutionEntities in SolutionEntities)
                {
                    var clonesolutionEntities = (CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase?)solutionEntities.Clone();
                    if (clonesolutionEntities is null)
                    {
                        return null;
                    }

                    newClonedObject.SolutionEntities.Add(clonesolutionEntities);
                }
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputMediaPoll castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Poll.Compare(castedOther.Poll))
            {
                return true;
            }

            if (CorrectAnswers is null && castedOther.CorrectAnswers is not null || CorrectAnswers is not null && castedOther.CorrectAnswers is null)
            {
                return true;
            }

            if (CorrectAnswers is not null && castedOther.CorrectAnswers is not null)
            {
                var correctAnswerssize = castedOther.CorrectAnswers.Count;
                if (correctAnswerssize != CorrectAnswers.Count)
                {
                    return true;
                }

                for (var i = 0; i < correctAnswerssize; i++)
                {
                    if (castedOther.CorrectAnswers[i] != CorrectAnswers[i])
                    {
                        return true;
                    }
                }
            }

            if (Solution != castedOther.Solution)
            {
                return true;
            }

            if (SolutionEntities is null && castedOther.SolutionEntities is not null || SolutionEntities is not null && castedOther.SolutionEntities is null)
            {
                return true;
            }

            if (SolutionEntities is not null && castedOther.SolutionEntities is not null)
            {
                var solutionEntitiessize = castedOther.SolutionEntities.Count;
                if (solutionEntitiessize != SolutionEntities.Count)
                {
                    return true;
                }

                for (var i = 0; i < solutionEntitiessize; i++)
                {
                    if (castedOther.SolutionEntities[i].Compare(SolutionEntities[i]))
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