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
    public partial class LabeledPrice : CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -886477832; }

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
            var newClonedObject = new LabeledPrice();
            newClonedObject.Label = Label;
            newClonedObject.Amount = Amount;
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