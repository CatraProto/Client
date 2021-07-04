using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChatParticipants : UpdateBase
	{


        public static int ConstructorId { get; } = 125178264;
		public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase Participants { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Participants);

		}

		public override void Deserialize(Reader reader)
		{
			Participants = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase>();

		}
	}
}