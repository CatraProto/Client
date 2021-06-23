using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionDefaultBannedRights : ChannelAdminLogEventActionBase
	{
		public static int ConstructorId { get; } = 771095562;
		public ChatBannedRightsBase PrevBannedRights { get; set; }
		public ChatBannedRightsBase NewBannedRights { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(PrevBannedRights);
			writer.Write(NewBannedRights);
		}

		public override void Deserialize(Reader reader)
		{
			PrevBannedRights = reader.Read<ChatBannedRightsBase>();
			NewBannedRights = reader.Read<ChatBannedRightsBase>();
		}
	}
}