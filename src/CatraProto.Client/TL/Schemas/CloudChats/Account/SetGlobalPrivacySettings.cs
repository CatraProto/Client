using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetGlobalPrivacySettings : IMethod
	{


        public static int ConstructorId { get; } = 517647042;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase Settings { get; set; }

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
			Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>();

		}
	}
}