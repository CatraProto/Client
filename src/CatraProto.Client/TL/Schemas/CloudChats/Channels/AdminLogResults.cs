using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class AdminLogResults : AdminLogResultsBase
	{


        public static int ConstructorId { get; } = -309659827;
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase> Events { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Events);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Events = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}