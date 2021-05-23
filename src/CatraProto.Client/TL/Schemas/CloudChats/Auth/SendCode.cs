using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SendCode : IMethod
	{


        public static int ConstructorId { get; } = -1502141361;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.SendCode);
		public bool IsVector { get; init; } = false;
		public string PhoneNumber { get; set; }
		public int ApiId { get; set; }
		public string ApiHash { get; set; }
		public CodeSettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneNumber);
			writer.Write(ApiId);
			writer.Write(ApiHash);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			ApiId = reader.Read<int>();
			ApiHash = reader.Read<string>();
			Settings = reader.Read<CodeSettingsBase>();

		}
	}
}