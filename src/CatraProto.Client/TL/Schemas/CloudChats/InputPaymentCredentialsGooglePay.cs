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
    public partial class InputPaymentCredentialsGooglePay : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1966921727; }

        [Newtonsoft.Json.JsonProperty("payment_token")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase PaymentToken { get; set; }


#nullable enable
        public InputPaymentCredentialsGooglePay(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase paymentToken)
        {
            PaymentToken = paymentToken;
        }
#nullable disable
        internal InputPaymentCredentialsGooglePay()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpaymentToken = writer.WriteObject(PaymentToken);
            if (checkpaymentToken.IsError)
            {
                return checkpaymentToken;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypaymentToken = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (trypaymentToken.IsError)
            {
                return ReadResult<IObject>.Move(trypaymentToken);
            }

            PaymentToken = trypaymentToken.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputPaymentCredentialsGooglePay";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPaymentCredentialsGooglePay();
            var clonePaymentToken = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)PaymentToken.Clone();
            if (clonePaymentToken is null)
            {
                return null;
            }

            newClonedObject.PaymentToken = clonePaymentToken;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPaymentCredentialsGooglePay castedOther)
            {
                return true;
            }

            if (PaymentToken.Compare(castedOther.PaymentToken))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}