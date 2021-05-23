using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SendConfirmPhoneCode : IMethod
	{


        public static int ConstructorId { get; } = 457157256;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.SendConfirmPhoneCode);
		public bool IsVector { get; init; } = false;
		public string Hash { get; set; }
		public CodeSettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<string>();
			Settings = reader.Read<CodeSettingsBase>();

		}
	}
}