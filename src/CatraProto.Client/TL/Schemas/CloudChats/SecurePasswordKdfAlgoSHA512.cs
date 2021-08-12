using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecurePasswordKdfAlgoSHA512 : SecurePasswordKdfAlgoBase
	{


        public static int StaticConstructorId { get => -2042159726; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("salt")]
		public byte[] Salt { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Salt);

		}

		public override void Deserialize(Reader reader)
		{
			Salt = reader.Read<byte[]>();
		}

		public override string ToString()
		{
			return "securePasswordKdfAlgoSHA512";
		}
	}
}