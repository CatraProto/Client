using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SentCodeTypeSms : SentCodeTypeBase
	{


        public static int StaticConstructorId { get => -1073693790; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("length")]
		public int Length { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Length);

		}

		public override void Deserialize(Reader reader)
		{
			Length = reader.Read<int>();
		}

		public override string ToString()
		{
			return "auth.sentCodeTypeSms";
		}
	}
}