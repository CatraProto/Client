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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -886477832; }
        
[Newtonsoft.Json.JsonProperty("label")]
		public sealed override string Label { get; set; }

[Newtonsoft.Json.JsonProperty("amount")]
		public sealed override long Amount { get; set; }


        #nullable enable
 public LabeledPrice (string label,long amount)
{
 Label = label;
Amount = amount;
 
}
#nullable disable
        internal LabeledPrice() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}