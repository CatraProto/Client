using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantToggleAdmin : ChannelAdminLogEventActionBase
	{


        public static int ConstructorId { get; } = -714643696;
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase PrevParticipant { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase NewParticipant { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevParticipant);
			writer.Write(NewParticipant);

		}

		public override void Deserialize(Reader reader)
		{
			PrevParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			NewParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();

		}
	}
}