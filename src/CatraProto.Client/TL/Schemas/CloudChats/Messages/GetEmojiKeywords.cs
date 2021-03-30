using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetEmojiKeywords : IMethod<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>
	{


        public static int ConstructorId { get; } = 899735650;

		public string LangCode { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);

		}

		public void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();

		}
	}
}