using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class HighScore : HighScoreBase
	{
		public static int ConstructorId { get; } = 1493171408;
		public override int Pos { get; set; }
		public override int UserId { get; set; }
		public override int Score { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
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