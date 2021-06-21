using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UpdateDialogFiltersOrder : IMethod
	{
		public static int ConstructorId { get; } = -983318044;
		public IList<int> Order { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Order);
		}

		public void Deserialize(Reader reader)
		{
			Order = reader.ReadVector<int>();
		}
	}
}