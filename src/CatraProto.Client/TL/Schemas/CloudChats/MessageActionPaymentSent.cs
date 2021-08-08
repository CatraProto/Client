using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionPaymentSent : MessageActionBase
	{


        public static int StaticConstructorId { get => 1080663248; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("currency")]
		public string Currency { get; set; }

[JsonPropertyName("total_amount")]
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
	}
}