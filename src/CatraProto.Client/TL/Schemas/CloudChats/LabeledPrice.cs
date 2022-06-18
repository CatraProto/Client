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
    public partial class LabeledPrice : CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -886477832; }

        [Newtonsoft.Json.JsonProperty("label")]
        public sealed override string Label { get; set; }

        [Newtonsoft.Json.JsonProperty("amount")]
        public sealed override long Amount { get; set; }


#nullable enable
        public LabeledPrice(string label, long amount)
        {
            Label = label;
            Amount = amount;

        }
#nullable disable
        internal LabeledPrice()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Label);
            writer.WriteInt64(Amount);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylabel = reader.ReadString();
            if (trylabel.IsError)
            {
                return ReadResult<IObject>.Move(trylabel);
            }
            Label = trylabel.Value;
            var tryamount = reader.ReadInt64();
            if (tryamount.IsError)
            {
                return ReadResult<IObject>.Move(tryamount);
            }
            Amount = tryamount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "labeledPrice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LabeledPrice
            {
                Label = Label,
                Amount = Amount
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not LabeledPrice castedOther)
            {
                return true;
            }
            if (Label != castedOther.Label)
            {
                return true;
            }
            if (Amount != castedOther.Amount)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}