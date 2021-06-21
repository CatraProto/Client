using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaPoll : MessageMediaBase
	{


        public static int ConstructorId { get; } = 1272375192;
		public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase Results { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Poll);
			writer.Write(Results);

		}

		public override void Deserialize(Reader reader)
		{
			Poll = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
			Results = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase>();

		}
	}
}