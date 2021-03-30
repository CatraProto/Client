using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RecentMeUrlUser : RecentMeUrlBase
	{


        public static int ConstructorId { get; } = -1917045962;
		public override string Url { get; set; }
		public int UserId { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			UserId = reader.Read<int>();

		}
	}
}