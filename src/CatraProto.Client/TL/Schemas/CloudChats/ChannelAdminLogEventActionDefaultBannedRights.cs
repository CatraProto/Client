using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionDefaultBannedRights : ChannelAdminLogEventActionBase
	{


        public static int ConstructorId { get; } = 771095562;
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase PrevBannedRights { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase NewBannedRights { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevBannedRights);
			writer.Write(NewBannedRights);

		}

		public override void Deserialize(Reader reader)
		{
			PrevBannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
			NewBannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();

		}
	}
}