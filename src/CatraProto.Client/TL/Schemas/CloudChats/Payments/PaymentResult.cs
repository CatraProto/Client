using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class PaymentResult : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1314881805; }
        
[Newtonsoft.Json.JsonProperty("updates")]
		public CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase Updates { get; set; }


        #nullable enable
 public PaymentResult (CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase updates)
{
 Updates = updates;
 
}
#nullable disable
        internal PaymentResult() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Updates);

		}

		public override void Deserialize(Reader reader)
		{
			Updates = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();

		}
		
		public override string ToString()
		{
		    return "payments.paymentResult";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}