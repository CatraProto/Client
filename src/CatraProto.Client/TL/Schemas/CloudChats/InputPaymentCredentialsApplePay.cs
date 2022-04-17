using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPaymentCredentialsApplePay : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 178373535; }

        [Newtonsoft.Json.JsonProperty("payment_data")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase PaymentData { get; set; }


#nullable enable
        public InputPaymentCredentialsApplePay(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase paymentData)
        {
            PaymentData = paymentData;

        }
#nullable disable
        internal InputPaymentCredentialsApplePay()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpaymentData = writer.WriteObject(PaymentData);
            if (checkpaymentData.IsError)
            {
                return checkpaymentData;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypaymentData = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (trypaymentData.IsError)
            {
                return ReadResult<IObject>.Move(trypaymentData);
            }
            PaymentData = trypaymentData.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputPaymentCredentialsApplePay";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}