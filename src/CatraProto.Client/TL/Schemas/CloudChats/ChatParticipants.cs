using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatParticipants : ChatParticipantsBase
	{


        public static int ConstructorId { get; } = 1061556205;
		public override int ChatId { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase> Participants { get; set; }
		public int Version { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(Participants);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			Participants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase>();
			Version = reader.Read<int>();

		}
	}
}