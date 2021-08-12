using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LabeledPrice : LabeledPriceBase
	{


        public static int StaticConstructorId { get => -886477832; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("label")]
		public override string Label { get; set; }

[JsonPropertyName("amount")]
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