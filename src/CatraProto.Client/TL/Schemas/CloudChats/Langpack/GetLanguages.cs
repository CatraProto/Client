using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetLanguages : IMethod
	{
		public static int ConstructorId { get; } = 1120311183;
		public string LangPack { get; set; }

		public Type Type { get; init; } = typeof(LangPackLanguageBase);
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
		}

		public void Deserialize(Reader reader)
		{
			LangPack = reader.Read<string>();
		}
	}
}