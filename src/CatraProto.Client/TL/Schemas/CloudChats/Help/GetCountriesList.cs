using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetCountriesList : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListBase>
	{


        public static int ConstructorId { get; } = 1935116200;

		public string LangCode { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
			Hash = reader.Read<int>();

		}
	}
}