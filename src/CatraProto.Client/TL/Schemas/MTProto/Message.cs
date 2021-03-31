using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Message : IMethod<CatraProto.Client.TL.Schemas.MTProto.MessageBase>
	{


        public static int ConstructorId { get; } = 0;

		public long MsgId { get; set; }
		public int Seqno { get; set; }
		public int Bytes { get; set; }
		public IObject Body { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(Seqno);
			writer.Write(Bytes);
			writer.Write(Body);

		}

		public void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			Seqno = reader.Read<int>();
			Bytes = reader.Read<int>();
			Body = reader.Read<IObject>();

		}
	}
}