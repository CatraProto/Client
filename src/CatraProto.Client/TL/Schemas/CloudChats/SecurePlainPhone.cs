using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecurePlainPhone : SecurePlainDataBase
	{


        public static int StaticConstructorId { get => 2103482845; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("phone")]
		public string Phone { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Phone);

		}

		public override void Deserialize(Reader reader)
		{
			Phone = reader.Read<string>();
		}

		public override string ToString()
		{
			return "securePlainPhone";
		}
	}
}