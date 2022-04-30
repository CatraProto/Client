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
    public partial class StatsGroupTopAdmin : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -682079097; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("deleted")]
        public sealed override int Deleted { get; set; }

        [Newtonsoft.Json.JsonProperty("kicked")]
        public sealed override int Kicked { get; set; }

        [Newtonsoft.Json.JsonProperty("banned")]
        public sealed override int Banned { get; set; }


#nullable enable
        public StatsGroupTopAdmin(long userId, int deleted, int kicked, int banned)
        {
            UserId = userId;
            Deleted = deleted;
            Kicked = kicked;
            Banned = banned;

        }
#nullable disable
        internal StatsGroupTopAdmin()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Deleted);
            writer.WriteInt32(Kicked);
            writer.WriteInt32(Banned);

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
            var trydeleted = reader.ReadInt32();
            if (trydeleted.IsError)
            {
                return ReadResult<IObject>.Move(trydeleted);
            }
            Deleted = trydeleted.Value;
            var trykicked = reader.ReadInt32();
            if (trykicked.IsError)
            {
                return ReadResult<IObject>.Move(trykicked);
            }
            Kicked = trykicked.Value;
            var trybanned = reader.ReadInt32();
            if (trybanned.IsError)
            {
                return ReadResult<IObject>.Move(trybanned);
            }
            Banned = trybanned.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsGroupTopAdmin";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsGroupTopAdmin
            {
                UserId = UserId,
                Deleted = Deleted,
                Kicked = Kicked,
                Banned = Banned
            };
            return newClonedObject;

        }
#nullable disable
    }
}