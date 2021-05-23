using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SendChangePhoneCode : IMethod
	{


        public static int ConstructorId { get; } = -2108208411;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.SendChangePhoneCode);
		public bool IsVector { get; init; } = false;
		public string PhoneNumber { get; set; }
		public CodeSettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneNumber);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			Settings = reader.Read<CodeSettingsBase>();

		}
	}
}