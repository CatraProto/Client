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
    public partial class UpdateMessagePoll : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Poll = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1398708869; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("poll_id")]
        public long PollId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("poll")]
        public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }

        [Newtonsoft.Json.JsonProperty("results")]
        public CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase Results { get; set; }


#nullable enable
        public UpdateMessagePoll(long pollId, CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase results)
        {
            PollId = pollId;
            Results = results;
        }
#nullable disable
        internal UpdateMessagePoll()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Poll == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(PollId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkpoll = writer.WriteObject(Poll);
                if (checkpoll.IsError)
                {
                    return checkpoll;
                }
            }

            var checkresults = writer.WriteObject(Results);
            if (checkresults.IsError)
            {
                return checkresults;
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
            var trypollId = reader.ReadInt64();
            if (trypollId.IsError)
            {
                return ReadResult<IObject>.Move(trypollId);
            }

            PollId = trypollId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trypoll = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
                if (trypoll.IsError)
                {
                    return ReadResult<IObject>.Move(trypoll);
                }

                Poll = trypoll.Value;
            }

            var tryresults = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase>();
            if (tryresults.IsError)
            {
                return ReadResult<IObject>.Move(tryresults);
            }

            Results = tryresults.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateMessagePoll";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateMessagePoll();
            newClonedObject.Flags = Flags;
            newClonedObject.PollId = PollId;
            if (Poll is not null)
            {
                var clonePoll = (CatraProto.Client.TL.Schemas.CloudChats.PollBase?)Poll.Clone();
                if (clonePoll is null)
                {
                    return null;
                }

                newClonedObject.Poll = clonePoll;
            }

            var cloneResults = (CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase?)Results.Clone();
            if (cloneResults is null)
            {
                return null;
            }

            newClonedObject.Results = cloneResults;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateMessagePoll castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (PollId != castedOther.PollId)
            {
                return true;
            }

            if (Poll is null && castedOther.Poll is not null || Poll is not null && castedOther.Poll is null)
            {
                return true;
            }

            if (Poll is not null && castedOther.Poll is not null && Poll.Compare(castedOther.Poll))
            {
                return true;
            }

            if (Results.Compare(castedOther.Results))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}