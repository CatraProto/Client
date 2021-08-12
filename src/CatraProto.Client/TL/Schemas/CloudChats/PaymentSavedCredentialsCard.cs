using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PaymentSavedCredentialsCard : PaymentSavedCredentialsBase
	{


        public static int StaticConstructorId { get => -842892769; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override string Id { get; set; }

[JsonPropertyName("title")]
		public override string Title { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Title);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			Title = reader.Read<string>();
		}

		public override string ToString()
		{
			return "paymentSavedCredentialsCard";
		}
	}
}