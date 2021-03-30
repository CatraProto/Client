using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class HighScores : HighScoresBase
	{


        public static int ConstructorId { get; } = -1707344487;
		public override IList<HighScoreBase> Scores { get; set; }
		public override IList<UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Scores);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Scores = reader.ReadVector<HighScoreBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}