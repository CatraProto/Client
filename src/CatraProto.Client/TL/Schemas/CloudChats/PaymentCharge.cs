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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -368917890; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("provider_charge_id")]
		public sealed override string ProviderChargeId { get; set; }


        #nullable enable
 public PaymentCharge (string id,string providerChargeId)
{
 Id = id;
ProviderChargeId = providerChargeId;
 
}
#nullable disable
        internal PaymentCharge() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}