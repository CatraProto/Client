using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetLanguage : IMethod<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>
	{


        public static int ConstructorId { get; } = 1784243458;

		public string LangPack { get; set; }
		public string LangCode { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
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