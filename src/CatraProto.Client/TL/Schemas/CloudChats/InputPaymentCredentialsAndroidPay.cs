using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsAndroidPay : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
	{


        public static int StaticConstructorId { get => -905587442; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("payment_token")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase PaymentToken { get; set; }

[JsonPropertyName("google_transaction_id")]
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
	}
}