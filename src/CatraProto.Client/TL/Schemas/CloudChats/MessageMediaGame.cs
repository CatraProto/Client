using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaGame : MessageMediaBase
	{


        public static int ConstructorId { get; } = -38694904;
		public CatraProto.Client.TL.Schemas.CloudChats.GameBase Game { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Game);

		}

		public override void Deserialize(Reader reader)
		{
			Game = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GameBase>();

		}
	}
}