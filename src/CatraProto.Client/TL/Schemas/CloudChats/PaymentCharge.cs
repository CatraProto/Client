using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PaymentCharge : CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase
	{


        public static int StaticConstructorId { get => -368917890; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("provider_charge_id")]
		public override string ProviderChargeId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(ProviderChargeId);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			ProviderChargeId = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "paymentCharge";
		}
	}
}