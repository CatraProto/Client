using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetNearestDc : IMethod
	{
		public static int ConstructorId { get; } = 531836966;

		public Type Type { get; init; } = typeof(NearestDcBase);
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