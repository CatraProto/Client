using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetStrings : IMethod
	{


        public static int ConstructorId { get; } = -269862909;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetStrings);
		public bool IsVector { get; init; } = false;
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