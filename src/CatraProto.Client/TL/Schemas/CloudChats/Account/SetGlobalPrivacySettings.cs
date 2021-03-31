using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetGlobalPrivacySettings : IMethod<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>
	{


        public static int ConstructorId { get; } = 517647042;

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