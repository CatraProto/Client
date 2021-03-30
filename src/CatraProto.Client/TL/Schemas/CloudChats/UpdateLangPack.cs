using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateLangPack : UpdateBase
	{


        public static int ConstructorId { get; } = 1442983757;
		public LangPackDifferenceBase Difference { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Difference);

		}

		public override void Deserialize(Reader reader)
		{
			Difference = reader.Read<LangPackDifferenceBase>();

		}
	}
}