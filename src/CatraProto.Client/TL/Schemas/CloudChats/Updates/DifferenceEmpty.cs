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
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class DifferenceEmpty : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1567990072; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("seq")]
        public int Seq { get; set; }


#nullable enable
        public DifferenceEmpty(int date, int seq)
        {
            Date = date;
            Seq = seq;

        }
#nullable disable
        internal DifferenceEmpty()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Date);
            writer.WriteInt32(Seq);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryseq = reader.ReadInt32();
            if (tryseq.IsError)
            {
                return ReadResult<IObject>.Move(tryseq);
            }
            Seq = tryseq.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updates.differenceEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DifferenceEmpty
            {
                Date = Date,
                Seq = Seq
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not DifferenceEmpty castedOther)
            {
                return true;
            }
            if (Date != castedOther.Date)
            {
                return true;
            }
            if (Seq != castedOther.Seq)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}