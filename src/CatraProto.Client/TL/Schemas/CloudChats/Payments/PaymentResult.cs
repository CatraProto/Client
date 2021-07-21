using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class PaymentResult : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase
	{


        public static int StaticConstructorId { get => 1314881805; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("updates")]
		public CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase Updates { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Updates);

		}

		public override void Deserialize(Reader reader)
		{
			Updates = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();

		}
	}
}