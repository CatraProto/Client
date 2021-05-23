using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateTheme : UpdateBase
	{


        public static int ConstructorId { get; } = -2112423005;
		public ThemeBase Theme { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Theme);

		}

		public override void Deserialize(Reader reader)
		{
			Theme = reader.Read<ThemeBase>();

		}
	}
}