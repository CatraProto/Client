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
    public partial class HighScore : CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1940093419; }

        [Newtonsoft.Json.JsonProperty("pos")]
        public sealed override int Pos { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("score")]
        public sealed override int Score { get; set; }


#nullable enable
        public HighScore(int pos, long userId, int score)
        {
            Pos = pos;
            UserId = userId;
            Score = score;

        }
#nullable disable
        internal HighScore()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Pos);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Score);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypos = reader.ReadInt32();
            if (trypos.IsError)
            {
                return ReadResult<IObject>.Move(trypos);
            }
            Pos = trypos.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
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
            return "highScore";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new HighScore
            {
                Pos = Pos,
                UserId = UserId,
                Score = Score
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not HighScore castedOther)
            {
                return true;
            }
            if (Pos != castedOther.Pos)
            {
                return true;
            }
            if (UserId != castedOther.UserId)
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