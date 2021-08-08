using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionGameScore : MessageActionBase
	{


        public static int StaticConstructorId { get => -1834538890; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("game_id")]
		public long GameId { get; set; }

[JsonPropertyName("score")]
		public int Score { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(GameId);
			writer.Write(Score);

		}

		public override void Deserialize(Reader reader)
		{
			GameId = reader.Read<long>();
			Score = reader.Read<int>();

		}
	}
}