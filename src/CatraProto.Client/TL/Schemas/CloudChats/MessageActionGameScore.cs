/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionGameScore : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1834538890; }

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
            var newClonedObject = new MessageActionGameScore
            {
                GameId = GameId,
                Score = Score
            };
            return newClonedObject;

        }
#nullable disable
    }
}