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
    public partial class UpdateBotStopped : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -997782967; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("stopped")]
        public bool Stopped { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")]
        public int Qts { get; set; }


#nullable enable
        public UpdateBotStopped(long userId, int date, bool stopped, int qts)
        {
            UserId = userId;
            Date = date;
            Stopped = stopped;
            Qts = qts;

        }
#nullable disable
        internal UpdateBotStopped()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Date);
            var checkstopped = writer.WriteBool(Stopped);
            if (checkstopped.IsError)
            {
                return checkstopped;
            }
            writer.WriteInt32(Qts);

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
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var trystopped = reader.ReadBool();
            if (trystopped.IsError)
            {
                return ReadResult<IObject>.Move(trystopped);
            }
            Stopped = trystopped.Value;
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
            return "updateBotStopped";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotStopped
            {
                UserId = UserId,
                Date = Date,
                Stopped = Stopped,
                Qts = Qts
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotStopped castedOther)
            {
                return true;
            }
            if (UserId != castedOther.UserId)
            {
                return true;
            }
            if (Date != castedOther.Date)
            {
                return true;
            }
            if (Stopped != castedOther.Stopped)
            {
                return true;
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