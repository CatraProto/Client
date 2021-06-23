using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetAllSecureValues : IMethod
	{
		public static int ConstructorId { get; } = -1299661699;

		public Type Type { get; init; } = typeof(SecureValueBase);
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
		}

		public void Deserialize(Reader reader)
		{
		}
	}
}