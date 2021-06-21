using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class GetCallConfig : IMethod
	{
		public static int ConstructorId { get; } = 1430593449;

		public Type Type { get; init; } = typeof(DataJSONBase);
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