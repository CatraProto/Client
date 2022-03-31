using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionGameScore : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1834538890; }
        
[Newtonsoft.Json.JsonProperty("game_id")]
		public long GameId { get; set; }

[Newtonsoft.Json.JsonProperty("score")]
		public int Score { get; set; }


        #nullable enable
 public MessageActionGameScore (long gameId,int score)
{
 GameId = gameId;
Score = score;
 
}
#nullable disable
        internal MessageActionGameScore() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(GameId);
			writer.Write(Score);

		}

		public override void Deserialize(Reader reader)
		{
			GameId = reader.Read<long>();
			Score = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messageActionGameScore";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}