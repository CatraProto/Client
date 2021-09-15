using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionPaymentSent : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        public static int StaticConstructorId { get => 1080663248; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("currency")]
		public string Currency { get; set; }

[Newtonsoft.Json.JsonProperty("total_amount")]
		public long TotalAmount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Currency);
			writer.Write(TotalAmount);

		}

		public override void Deserialize(Reader reader)
		{
			Currency = reader.Read<string>();
			TotalAmount = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "messageActionPaymentSent";
		}
	}
}