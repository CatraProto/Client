using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdatePasswordSettings : IMethod<bool>
	{


        public static int ConstructorId { get; } = -1516564433;

		public InputCheckPasswordSRPBase Password { get; set; }
		public PasswordInputSettingsBase NewSettings { get; set; }

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
			Password = reader.Read<InputCheckPasswordSRPBase>();
			NewSettings = reader.Read<PasswordInputSettingsBase>();

		}
	}
}