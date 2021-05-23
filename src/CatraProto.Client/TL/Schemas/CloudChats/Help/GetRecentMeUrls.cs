using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetRecentMeUrls : IMethod
	{


        public static int ConstructorId { get; } = 1036054804;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Help.GetRecentMeUrls);
		public bool IsVector { get; init; } = false;
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