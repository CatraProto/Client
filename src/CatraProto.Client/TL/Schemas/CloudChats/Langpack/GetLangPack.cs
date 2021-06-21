using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetLangPack : IMethod
	{


        public static int ConstructorId { get; } = -219008246;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase);
		public bool IsVector { get; init; } = false;
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