using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetDifference : IMethod
	{
		public static int ConstructorId { get; } = -845657435;
		public string LangPack { get; set; }
		public string LangCode { get; set; }
		public int FromVersion { get; set; }

		public Type Type { get; init; } = typeof(LangPackDifferenceBase);
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

			writer.Write(LangPack);
			writer.Write(LangCode);
			writer.Write(FromVersion);
		}

		public void Deserialize(Reader reader)
		{
			LangPack = reader.Read<string>();
			LangCode = reader.Read<string>();
			FromVersion = reader.Read<int>();
		}
	}
}