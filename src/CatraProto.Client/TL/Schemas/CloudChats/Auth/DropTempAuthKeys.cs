using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class DropTempAuthKeys : IMethod
	{
		public static int ConstructorId { get; } = -1907842680;
		public IList<long> ExceptAuthKeys { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ExceptAuthKeys);
		}

		public void Deserialize(Reader reader)
		{
			ExceptAuthKeys = reader.ReadVector<long>();
		}
	}
}