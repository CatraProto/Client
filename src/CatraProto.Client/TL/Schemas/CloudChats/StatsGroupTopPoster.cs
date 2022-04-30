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
    public partial class StatsGroupTopPoster : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1660637285; }

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
            var newClonedObject = new StatsGroupTopPoster
            {
                UserId = UserId,
                Messages = Messages,
                AvgChars = AvgChars
            };
            return newClonedObject;

        }
#nullable disable
    }
}