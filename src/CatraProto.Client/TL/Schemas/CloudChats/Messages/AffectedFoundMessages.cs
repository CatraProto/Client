using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AffectedFoundMessages : CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedFoundMessagesBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -275956116; }

        [Newtonsoft.Json.JsonProperty("pts")] public sealed override int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public sealed override int PtsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override List<int> Messages { get; set; }


#nullable enable
        public AffectedFoundMessages(int pts, int ptsCount, int offset, List<int> messages)
        {
            Pts = pts;
            PtsCount = ptsCount;
            Offset = offset;
            Messages = messages;
        }
#nullable disable
        internal AffectedFoundMessages()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Pts);
            writer.WriteInt32(PtsCount);
            writer.WriteInt32(Offset);

            writer.WriteVector(Messages, false);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }

            Pts = trypts.Value;
            var tryptsCount = reader.ReadInt32();
            if (tryptsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryptsCount);
            }

            PtsCount = tryptsCount.Value;
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }

            Offset = tryoffset.Value;
            var trymessages = reader.ReadVector<int>(ParserTypes.Int);
            if (trymessages.IsError)
            {
                return ReadResult<IObject>.Move(trymessages);
            }

            Messages = trymessages.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.affectedFoundMessages";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AffectedFoundMessages();
            newClonedObject.Pts = Pts;
            newClonedObject.PtsCount = PtsCount;
            newClonedObject.Offset = Offset;
            newClonedObject.Messages = new List<int>();
            foreach (var messages in Messages)
            {
                newClonedObject.Messages.Add(messages);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not AffectedFoundMessages castedOther)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (PtsCount != castedOther.PtsCount)
            {
                return true;
            }

            if (Offset != castedOther.Offset)
            {
                return true;
            }

            var messagessize = castedOther.Messages.Count;
            if (messagessize != Messages.Count)
            {
                return true;
            }

            for (var i = 0; i < messagessize; i++)
            {
                if (castedOther.Messages[i] != Messages[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}