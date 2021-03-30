using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ImportBotAuthorization : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>
	{


        public static int ConstructorId { get; } = 1738800940;

		public int Flags { get; set; }
		public int ApiId { get; set; }
		public string ApiHash { get; set; }
		public string BotAuthToken { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Flags);
			writer.Write(ApiId);
			writer.Write(ApiHash);
			writer.Write(BotAuthToken);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ApiId = reader.Read<int>();
			ApiHash = reader.Read<string>();
			BotAuthToken = reader.Read<string>();

		}
	}
}