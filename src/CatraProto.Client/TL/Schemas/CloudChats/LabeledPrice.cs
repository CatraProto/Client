using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LabeledPrice : CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase
	{


        public static int StaticConstructorId { get => -886477832; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("label")]
		public override string Label { get; set; }

[Newtonsoft.Json.JsonProperty("amount")]
		public override long Amount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Label);
			writer.Write(Amount);

		}

		public override void Deserialize(Reader reader)
		{
			Label = reader.Read<string>();
			Amount = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "labeledPrice";
		}
	}
}