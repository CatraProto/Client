using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SignIn : IMethod
	{
		public static int ConstructorId { get; } = -1126886015;
		public string PhoneNumber { get; set; }
		public string PhoneCodeHash { get; set; }
		public string PhoneCode { get; set; }

		public Type Type { get; init; } = typeof(AuthorizationBase);
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

			writer.Write(PhoneNumber);
			writer.Write(PhoneCodeHash);
			writer.Write(PhoneCode);
		}

		public void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			PhoneCodeHash = reader.Read<string>();
			PhoneCode = reader.Read<string>();
		}
	}
}