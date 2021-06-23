using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdatePasswordSettings : IMethod
	{
		public static int ConstructorId { get; } = -1516564433;
		public InputCheckPasswordSRPBase Password { get; set; }
		public PasswordInputSettingsBase NewSettings { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

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