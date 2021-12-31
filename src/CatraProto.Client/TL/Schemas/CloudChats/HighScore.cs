using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class HighScore : CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase
	{


        public static int StaticConstructorId { get => 1940093419; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("pos")]
		public override int Pos { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("score")]
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
			UserId = reader.Read<long>();
			Score = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "highScore";
		}
	}
}