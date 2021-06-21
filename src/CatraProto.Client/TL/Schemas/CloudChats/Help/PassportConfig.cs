using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class PassportConfig : PassportConfigBase
	{


        public static int ConstructorId { get; } = -1600596305;
		public int Hash { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase CountriesLangs { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(CountriesLangs);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			CountriesLangs = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
	}
}