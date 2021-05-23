using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNewChannelMessage : UpdateBase
	{


        public static int ConstructorId { get; } = 1656358105;
		public MessageBase Message { get; set; }
		public int Pts { get; set; }
		public int PtsCount { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Message);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<MessageBase>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
	}
}