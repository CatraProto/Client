using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetEmojiKeywordsLanguages : IMethod
	{


        public static int ConstructorId { get; } = 1318675378;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase);
		public bool IsVector { get; init; } = false;
		public IList<string> LangCodes { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCodes);

		}

		public void Deserialize(Reader reader)
		{
			LangCodes = reader.ReadVector<string>();

		}
	}
}