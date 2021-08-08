using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsApplePay : InputPaymentCredentialsBase
	{


        public static int StaticConstructorId { get => 178373535; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("payment_data")]
		public DataJSONBase PaymentData { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PaymentData);

		}

		public override void Deserialize(Reader reader)
		{
			PaymentData = reader.Read<DataJSONBase>();

		}
	}
}