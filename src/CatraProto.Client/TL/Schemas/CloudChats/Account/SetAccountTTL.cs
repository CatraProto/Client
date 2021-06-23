using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetAccountTTL : IMethod
	{
		public static int ConstructorId { get; } = 608323678;
		public AccountDaysTTLBase Ttl { get; set; }

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

			writer.Write(Ttl);
		}

		public void Deserialize(Reader reader)
		{
			Ttl = reader.Read<AccountDaysTTLBase>();
		}
	}
}