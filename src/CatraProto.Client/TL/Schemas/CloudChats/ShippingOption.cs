using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ShippingOption : ShippingOptionBase
	{


        public static int StaticConstructorId { get => -1239335713; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override string Id { get; set; }

[JsonPropertyName("title")]
		public override string Title { get; set; }

[JsonPropertyName("prices")]
		public override IList<LabeledPriceBase> Prices { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Title);
			writer.Write(Prices);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			Title = reader.Read<string>();
			Prices = reader.ReadVector<LabeledPriceBase>();
		}

		public override string ToString()
		{
			return "shippingOption";
		}
	}
}