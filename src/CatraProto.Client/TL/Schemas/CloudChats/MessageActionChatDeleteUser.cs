using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatDeleteUser : MessageActionBase
	{


        public static int ConstructorId { get; } = -1297179892;
		public int UserId { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();

		}
	}
}