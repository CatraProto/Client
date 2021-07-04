using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInvitePeek : ChatInviteBase
	{


        public static int ConstructorId { get; } = 1634294960;
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }
		public int Expires { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Chat);
			writer.Write(Expires);

		}

		public override void Deserialize(Reader reader)
		{
			Chat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Expires = reader.Read<int>();

		}
	}
}