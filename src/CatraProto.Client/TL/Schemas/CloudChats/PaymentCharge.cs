using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PaymentCharge : PaymentChargeBase
	{


        public static int StaticConstructorId { get => -368917890; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override string Id { get; set; }

[JsonPropertyName("provider_charge_id")]
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