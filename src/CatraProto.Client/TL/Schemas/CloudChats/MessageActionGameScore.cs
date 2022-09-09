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
    public partial class MessageActionGameScore : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1834538890; }

        [Newtonsoft.Json.JsonProperty("game_id")]
        public long GameId { get; set; }

        [Newtonsoft.Json.JsonProperty("score")]
        public int Score { get; set; }


#nullable enable
        public MessageActionGameScore(long gameId, int score)
        {
            GameId = gameId;
            Score = score;
        }
#nullable disable
        internal MessageActionGameScore()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(GameId);
            writer.WriteInt32(Score);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trygameId = reader.ReadInt64();
            if (trygameId.IsError)
            {
                return ReadResult<IObject>.Move(trygameId);
            }

            GameId = trygameId.Value;
            var tryscore = reader.ReadInt32();
            if (tryscore.IsError)
            {
                return ReadResult<IObject>.Move(tryscore);
            }

            Score = tryscore.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionGameScore";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionGameScore();
            newClonedObject.GameId = GameId;
            newClonedObject.Score = Score;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionGameScore castedOther)
            {
                return true;
            }

            if (GameId != castedOther.GameId)
            {
                return true;
            }

            if (Score != castedOther.Score)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}