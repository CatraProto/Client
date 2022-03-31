using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class PaymentVerificationNeeded : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -666824391; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }


        #nullable enable
 public PaymentVerificationNeeded (string url)
{
 Url = url;
 
}
#nullable disable
        internal PaymentVerificationNeeded() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "payments.paymentVerificationNeeded";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}