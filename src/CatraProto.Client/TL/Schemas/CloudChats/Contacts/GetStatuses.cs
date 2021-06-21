using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class GetStatuses : IMethod
	{
		public static int ConstructorId { get; } = -995929106;

		public Type Type { get; init; } = typeof(ContactStatusBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
		}

		public void Deserialize(Reader reader)
		{
		}
	}
}