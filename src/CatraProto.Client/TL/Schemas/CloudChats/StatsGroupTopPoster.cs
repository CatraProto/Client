using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGroupTopPoster : StatsGroupTopPosterBase
	{


        public static int ConstructorId { get; } = 418631927;
		public override int UserId { get; set; }
		public override int Messages { get; set; }
		public override int AvgChars { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Messages);
			writer.Write(AvgChars);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Messages = reader.Read<int>();
			AvgChars = reader.Read<int>();

		}
	}
}