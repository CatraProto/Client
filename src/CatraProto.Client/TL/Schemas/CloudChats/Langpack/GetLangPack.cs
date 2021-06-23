using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetLangPack : IMethod
	{
		public static int ConstructorId { get; } = -219008246;
		public string LangPack { get; set; }
		public string LangCode { get; set; }

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
		}

		public void Deserialize(Reader reader)
		{
			LangPack = reader.Read<string>();
			LangCode = reader.Read<string>();
		}
	}
}