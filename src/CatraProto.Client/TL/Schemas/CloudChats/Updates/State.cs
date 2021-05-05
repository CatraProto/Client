using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class State : StateBase
	{


        public static int ConstructorId { get; } = -1519637954;
		public override int Pts { get; set; }
		public override int Qts { get; set; }
		public override int Date { get; set; }
		public override int Seq { get; set; }
		public override int UnreadCount { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pts);
			writer.Write(Qts);
			writer.Write(Date);
			writer.Write(Seq);
			writer.Write(UnreadCount);

		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();
			Qts = reader.Read<int>();
			Date = reader.Read<int>();
			Seq = reader.Read<int>();
			UnreadCount = reader.Read<int>();

		}
	}
}