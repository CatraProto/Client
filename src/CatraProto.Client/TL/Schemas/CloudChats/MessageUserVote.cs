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
    public partial class MessageUserVote : CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 886196148; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("option")]
        public byte[] Option { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }


#nullable enable
        public MessageUserVote(long userId, byte[] option, int date)
        {
            UserId = userId;
            Option = option;
            Date = date;

        }
#nullable disable
        internal MessageUserVote()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);

            writer.WriteBytes(Option);
            writer.WriteInt32(Date);

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
            var tryoption = reader.ReadBytes();
            if (tryoption.IsError)
            {
                return ReadResult<IObject>.Move(tryoption);
            }
            Option = tryoption.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageUserVote";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageUserVote
            {
                UserId = UserId,
                Option = Option,
                Date = Date
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageUserVote castedOther)
            {
                return true;
            }
            if (UserId != castedOther.UserId)
            {
                return true;
            }
            if (Option != castedOther.Option)
            {
                return true;
            }
            if (Date != castedOther.Date)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}