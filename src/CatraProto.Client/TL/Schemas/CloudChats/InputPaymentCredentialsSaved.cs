using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsSaved : InputPaymentCredentialsBase
	{


        public static int StaticConstructorId { get => -1056001329; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public string Id { get; set; }

[JsonPropertyName("tmp_password")]
		public byte[] TmpPassword { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(TmpPassword);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			TmpPassword = reader.Read<byte[]>();
		}

		public override string ToString()
		{
			return "inputPaymentCredentialsSaved";
		}
	}
}