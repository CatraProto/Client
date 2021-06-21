using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Message : MessageBase
	{


        public static int ConstructorId { get; } = 0;
		public override long MsgId { get; set; }
		public override int Seqno { get; set; }
		public override int Bytes { get; set; }
		public override IObject Body { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(Seqno);
			writer.Write(Bytes);
			writer.Write(Body);

		}

		public override void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			Seqno = reader.Read<int>();
			Bytes = reader.Read<int>();
			Body = reader.Read<IObject>();

		}
	}
}