using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockAnchor : PageBlockBase
	{


        public static int StaticConstructorId { get => -837994576; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("name")]
		public string Name { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Name);

		}

		public override void Deserialize(Reader reader)
		{
			Name = reader.Read<string>();
		}

		public override string ToString()
		{
			return "pageBlockAnchor";
		}
	}
}