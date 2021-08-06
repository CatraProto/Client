using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class HighScore : CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase
	{


        public static int StaticConstructorId { get => 1493171408; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("pos")]
		public override int Pos { get; set; }

[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("score")]
		public override int Score { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pos);
			writer.Write(UserId);
			writer.Write(Score);

		}

		public override void Deserialize(Reader reader)
		{
			Pos = reader.Read<int>();
			UserId = reader.Read<int>();
			Score = reader.Read<int>();

		}
	}
}