using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateTheme : UpdateBase
	{


        public static int StaticConstructorId { get => -2112423005; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("theme")]
		public ThemeBase Theme { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Theme);

		}

		public override void Deserialize(Reader reader)
		{
			Theme = reader.Read<ThemeBase>();
		}

		public override string ToString()
		{
			return "updateTheme";
		}
	}
}