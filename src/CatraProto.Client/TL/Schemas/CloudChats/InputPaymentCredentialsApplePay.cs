using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsApplePay : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
	{


        public static int StaticConstructorId { get => 178373535; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("payment_data")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase PaymentData { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PaymentData);

		}

		public override void Deserialize(Reader reader)
		{
			PaymentData = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
	}
}