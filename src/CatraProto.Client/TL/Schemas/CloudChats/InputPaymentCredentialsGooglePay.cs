using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsGooglePay : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1966921727; }
        
[Newtonsoft.Json.JsonProperty("payment_token")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase PaymentToken { get; set; }


        #nullable enable
 public InputPaymentCredentialsGooglePay (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase paymentToken)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PaymentToken);

		}

		public override void Deserialize(Reader reader)
		{
			PaymentToken = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
		
		public override string ToString()
		{
		    return "inputPaymentCredentialsGooglePay";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}