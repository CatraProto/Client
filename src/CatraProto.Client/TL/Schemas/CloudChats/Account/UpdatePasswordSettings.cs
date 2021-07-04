using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdatePasswordSettings : IMethod
	{


        public static int ConstructorId { get; } = -1516564433;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase NewSettings { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Password);
			writer.Write(NewSettings);

		}

		public void Deserialize(Reader reader)
		{
			Password = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
			NewSettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase>();

		}
	}
}