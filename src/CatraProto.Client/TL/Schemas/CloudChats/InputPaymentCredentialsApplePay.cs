using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsApplePay : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
	{


        public static int StaticConstructorId { get => 178373535; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("payment_data")]
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
				
		public override string ToString()
		{
		    return "inputPaymentCredentialsApplePay";
		}
	}
}