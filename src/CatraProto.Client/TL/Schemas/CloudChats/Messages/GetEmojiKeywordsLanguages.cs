using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetEmojiKeywordsLanguages : IMethod<CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase>
	{


        public static int ConstructorId { get; } = 1318675378;

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