using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsAndroidPay : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
	{


        public static int StaticConstructorId { get => -905587442; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("payment_token")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase PaymentToken { get; set; }

[Newtonsoft.Json.JsonProperty("google_transaction_id")]
		public string GoogleTransactionId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PaymentToken);
			writer.Write(GoogleTransactionId);

		}

		public override void Deserialize(Reader reader)
		{
			PaymentToken = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
			GoogleTransactionId = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "inputPaymentCredentialsAndroidPay";
		}
	}
}