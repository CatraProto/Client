using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetMultiWallPapers : IMethod
	{
		public static int ConstructorId { get; } = 1705865692;
		public IList<InputWallPaperBase> Wallpapers { get; set; }

		public Type Type { get; init; } = typeof(WallPaperBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Wallpapers);
		}

		public void Deserialize(Reader reader)
		{
			Wallpapers = reader.ReadVector<InputWallPaperBase>();
		}
	}
}