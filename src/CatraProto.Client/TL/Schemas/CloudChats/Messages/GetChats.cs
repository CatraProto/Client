using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetChats : IMethod
	{
		public static int ConstructorId { get; } = 1013621127;
		public IList<int> Id { get; set; }

		public Type Type { get; init; } = typeof(ChatsBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
		}

		public void Deserialize(Reader reader)
		{
			Id = reader.ReadVector<int>();
		}
	}
}