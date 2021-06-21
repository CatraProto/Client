using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetTheme : IMethod
	{
		public static int ConstructorId { get; } = -1919060949;
		public string Format { get; set; }
		public InputThemeBase Theme { get; set; }
		public long DocumentId { get; set; }

		public Type Type { get; init; } = typeof(ThemeBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Format);
			writer.Write(Theme);
			writer.Write(DocumentId);
		}

		public void Deserialize(Reader reader)
		{
			Format = reader.Read<string>();
			Theme = reader.Read<InputThemeBase>();
			DocumentId = reader.Read<long>();
		}
	}
}