using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ChatsSlice : ChatsBase
	{


        public static int ConstructorId { get; } = -1663561404;
		public int Count { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats_ { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(Chats_);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			Chats_ = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();

		}
	}
}