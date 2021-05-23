using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatAddUser : MessageActionBase
	{


        public static int ConstructorId { get; } = 1217033015;
		public IList<int> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Users = reader.ReadVector<int>();

		}
	}
}