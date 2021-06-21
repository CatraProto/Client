using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteAlready : ChatInviteBase
	{


        public static int ConstructorId { get; } = 1516793212;
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Chat);

		}

		public override void Deserialize(Reader reader)
		{
			Chat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();

		}
	}
}