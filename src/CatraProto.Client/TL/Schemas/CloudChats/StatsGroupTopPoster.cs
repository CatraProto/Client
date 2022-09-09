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
    public partial class StatsGroupTopPoster : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1660637285; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override int Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("avg_chars")]
        public sealed override int AvgChars { get; set; }


#nullable enable
        public StatsGroupTopPoster(long userId, int messages, int avgChars)
        {
            UserId = userId;
            Messages = messages;
            AvgChars = avgChars;
        }
#nullable disable
        internal StatsGroupTopPoster()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Messages);
            writer.WriteInt32(AvgChars);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var trymessages = reader.ReadInt32();
            if (trymessages.IsError)
            {
                return ReadResult<IObject>.Move(trymessages);
            }

            Messages = trymessages.Value;
            var tryavgChars = reader.ReadInt32();
            if (tryavgChars.IsError)
            {
                return ReadResult<IObject>.Move(tryavgChars);
            }

            AvgChars = tryavgChars.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "statsGroupTopPoster";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsGroupTopPoster();
            newClonedObject.UserId = UserId;
            newClonedObject.Messages = Messages;
            newClonedObject.AvgChars = AvgChars;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsGroupTopPoster castedOther)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Messages != castedOther.Messages)
            {
                return true;
            }

            if (AvgChars != castedOther.AvgChars)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}