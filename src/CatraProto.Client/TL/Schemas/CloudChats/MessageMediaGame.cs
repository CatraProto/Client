using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaGame : MessageMediaBase
	{


        public static int StaticConstructorId { get => -38694904; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("game")]
		public GameBase Game { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Game);

		}

		public override void Deserialize(Reader reader)
		{
			Game = reader.Read<GameBase>();

		}
	}
}