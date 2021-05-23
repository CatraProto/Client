using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetGlobalPrivacySettings : IMethod
	{


        public static int ConstructorId { get; } = 517647042;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.SetGlobalPrivacySettings);
		public bool IsVector { get; init; } = false;
		public GlobalPrivacySettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Settings = reader.Read<GlobalPrivacySettingsBase>();

		}
	}
}