using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ChannelParticipants : ChannelParticipantsBase
	{
		public static int ConstructorId { get; } = -177282392;
		public int Count { get; set; }
		public IList<CloudChats.ChannelParticipantBase> Participants { get; set; }
		public IList<UserBase> Users { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(Participants);
			writer.Write(Users);
		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			Participants = reader.ReadVector<CloudChats.ChannelParticipantBase>();
			Users = reader.ReadVector<UserBase>();
		}
	}
}