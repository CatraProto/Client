using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackDifference : LangPackDifferenceBase
	{


        public static int ConstructorId { get; } = -209337866;
		public override string LangCode { get; set; }
		public override int FromVersion { get; set; }
		public override int Version { get; set; }
		public override IList<LangPackStringBase> Strings { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);
			writer.Write(FromVersion);
			writer.Write(Version);
			writer.Write(Strings);

		}

		public override void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
			FromVersion = reader.Read<int>();
			Version = reader.Read<int>();
			Strings = reader.ReadVector<LangPackStringBase>();

		}
	}
}