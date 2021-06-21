using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class CountriesList : CountriesListBase
	{
		public static int ConstructorId { get; } = -2016381538;
		public IList<CountryBase> Countries { get; set; }
		public int Hash { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Countries);
			writer.Write(Hash);
		}

		public override void Deserialize(Reader reader)
		{
			Countries = reader.ReadVector<CountryBase>();
			Hash = reader.Read<int>();
		}
	}
}