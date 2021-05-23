using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcAnswerDropped : IMethod
	{


        public static int ConstructorId { get; } = -1539647305;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.RpcAnswerDropped);
		public bool IsVector { get; init; } = false;
		public long MsgId { get; set; }
		public int SeqNo { get; set; }
		public int Bytes { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(SeqNo);
			writer.Write(Bytes);

		}

		public void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			SeqNo = reader.Read<int>();
			Bytes = reader.Read<int>();

		}
	}
}