using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaDice : InputMediaBase
	{


        public static int ConstructorId { get; } = -428884101;
		public string Emoticon { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Emoticon);

		}

		public override void Deserialize(Reader reader)
		{
			Emoticon = reader.Read<string>();

		}
	}
}