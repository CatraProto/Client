using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetSecureValue : IMethod
	{
		public static int ConstructorId { get; } = 1936088002;
		public IList<SecureValueTypeBase> Types { get; set; }

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

			writer.Write(Types);
		}

		public void Deserialize(Reader reader)
		{
			Types = reader.ReadVector<SecureValueTypeBase>();
		}
	}
}