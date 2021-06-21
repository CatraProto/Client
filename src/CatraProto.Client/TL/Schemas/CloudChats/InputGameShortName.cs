using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputGameShortName : InputGameBase
	{


        public static int ConstructorId { get; } = -1020139510;
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase BotId { get; set; }
		public string ShortName { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BotId);
			writer.Write(ShortName);

		}

		public override void Deserialize(Reader reader)
		{
			BotId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			ShortName = reader.Read<string>();

		}
	}
}