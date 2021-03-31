using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetLangPack : IMethod<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>
	{


        public static int ConstructorId { get; } = -219008246;

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