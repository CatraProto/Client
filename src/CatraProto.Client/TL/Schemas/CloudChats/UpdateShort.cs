using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateShort : UpdatesBase
	{


        public static int ConstructorId { get; } = 2027216577;
		public CatraProto.Client.TL.Schemas.CloudChats.UpdateBase Update { get; set; }
		public int Date { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Update);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Update = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
			Date = reader.Read<int>();

		}
	}
}