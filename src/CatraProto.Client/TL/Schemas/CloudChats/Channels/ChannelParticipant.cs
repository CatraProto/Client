using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ChannelParticipant : ChannelParticipantBase
	{


        public static int ConstructorId { get; } = -791039645;
		public override CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase Participant { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Participant);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}