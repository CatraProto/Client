using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class HighScores : CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase
	{


        public static int StaticConstructorId { get => -1707344487; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("scores")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase> Scores { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public HighScores (IList<CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase> scores,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Scores = scores;
Users = users;
 
}
#nullable disable
        internal HighScores() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Scores);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Scores = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.HighScoreBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "messages.highScores";
		}
	}
}