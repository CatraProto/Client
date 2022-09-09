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
    public partial class UpdateMessagePollVote : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 274961865; }

        [Newtonsoft.Json.JsonProperty("poll_id")]
        public long PollId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("options")]
        public List<byte[]> Options { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")] public int Qts { get; set; }


#nullable enable
        public UpdateMessagePollVote(long pollId, long userId, List<byte[]> options, int qts)
        {
            PollId = pollId;
            UserId = userId;
            Options = options;
            Qts = qts;
        }
#nullable disable
        internal UpdateMessagePollVote()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(PollId);
            writer.WriteInt64(UserId);

            writer.WriteVector(Options, false);
            writer.WriteInt32(Qts);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypollId = reader.ReadInt64();
            if (trypollId.IsError)
            {
                return ReadResult<IObject>.Move(trypollId);
            }

            PollId = trypollId.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryoptions = reader.ReadVector<byte[]>(ParserTypes.Bytes, nakedVector: false, nakedObjects: false);
            if (tryoptions.IsError)
            {
                return ReadResult<IObject>.Move(tryoptions);
            }

            Options = tryoptions.Value;
            var tryqts = reader.ReadInt32();
            if (tryqts.IsError)
            {
                return ReadResult<IObject>.Move(tryqts);
            }

            Qts = tryqts.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateMessagePollVote";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateMessagePollVote();
            newClonedObject.PollId = PollId;
            newClonedObject.UserId = UserId;
            newClonedObject.Options = new List<byte[]>();
            foreach (var options in Options)
            {
                newClonedObject.Options.Add(options);
            }

            newClonedObject.Qts = Qts;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateMessagePollVote castedOther)
            {
                return true;
            }

            if (PollId != castedOther.PollId)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            var optionssize = castedOther.Options.Count;
            if (optionssize != Options.Count)
            {
                return true;
            }

            for (var i = 0; i < optionssize; i++)
            {
                if (castedOther.Options[i] != Options[i])
                {
                    return true;
                }
            }

            if (Qts != castedOther.Qts)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}