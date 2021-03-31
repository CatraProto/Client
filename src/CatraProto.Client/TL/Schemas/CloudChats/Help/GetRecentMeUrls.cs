using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetRecentMeUrls : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrlsBase>
	{


        public static int ConstructorId { get; } = 1036054804;

		public string Referer { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Referer);

		}

		public void Deserialize(Reader reader)
		{
			Referer = reader.Read<string>();

		}
	}
}