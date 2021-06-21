using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetEmojiKeywords : IMethod
	{
		public static int ConstructorId { get; } = 899735650;
		public string LangCode { get; set; }

		public Type Type { get; init; } = typeof(EmojiKeywordsDifferenceBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);
		}

		public void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
		}
	}
}