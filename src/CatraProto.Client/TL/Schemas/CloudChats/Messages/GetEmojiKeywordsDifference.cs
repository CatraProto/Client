using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetEmojiKeywordsDifference : IMethod<EmojiKeywordsDifferenceBase>
	{


        public static int ConstructorId { get; } = 352892591;

		public Type Type { get; init; } = typeof(GetEmojiKeywordsDifference);
		public bool IsVector { get; init; } = false;
		public string LangCode { get; set; }
		public int FromVersion { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);
			writer.Write(FromVersion);

		}

		public void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
			FromVersion = reader.Read<int>();

		}
	}
}