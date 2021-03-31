using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetStrings : IMethod<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>
	{


        public static int ConstructorId { get; } = -269862909;

		public string LangPack { get; set; }
		public string LangCode { get; set; }
		public IList<string> Keys { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangPack);
			writer.Write(LangCode);
			writer.Write(Keys);

		}

		public void Deserialize(Reader reader)
		{
			LangPack = reader.Read<string>();
			LangCode = reader.Read<string>();
			Keys = reader.ReadVector<string>();

		}
	}
}