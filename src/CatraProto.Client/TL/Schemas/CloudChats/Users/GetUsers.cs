using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class GetUsers : IMethod
	{
		public static int ConstructorId { get; } = 227648840;
		public IList<InputUserBase> Id { get; set; }

		public Type Type { get; init; } = typeof(UserBase);
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

			writer.Write(Id);
		}

		public void Deserialize(Reader reader)
		{
			Id = reader.ReadVector<InputUserBase>();
		}
	}
}