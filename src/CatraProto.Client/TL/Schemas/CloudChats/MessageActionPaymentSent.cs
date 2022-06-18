using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionPaymentSent : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1080663248; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("total_amount")]
        public long TotalAmount { get; set; }


#nullable enable
        public MessageActionPaymentSent(string currency, long totalAmount)
        {
            Currency = currency;
            TotalAmount = totalAmount;

        }
#nullable disable
        internal MessageActionPaymentSent()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Currency);
            writer.WriteInt64(TotalAmount);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycurrency = reader.ReadString();
            if (trycurrency.IsError)
            {
                return ReadResult<IObject>.Move(trycurrency);
            }
            Currency = trycurrency.Value;
            var trytotalAmount = reader.ReadInt64();
            if (trytotalAmount.IsError)
            {
                return ReadResult<IObject>.Move(trytotalAmount);
            }
            TotalAmount = trytotalAmount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageActionPaymentSent";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionPaymentSent
            {
                Currency = Currency,
                TotalAmount = TotalAmount
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionPaymentSent castedOther)
            {
                return true;
            }
            if (Currency != castedOther.Currency)
            {
                return true;
            }
            if (TotalAmount != castedOther.TotalAmount)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}