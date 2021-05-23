using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsStateInfo : IMethod
	{


        public static int ConstructorId { get; } = 81704317;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfo);
		public bool IsVector { get; init; } = false;
		public long ReqMsgId { get; set; }
		public byte[] Info { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ReqMsgId);
			writer.Write(Info);

		}

		public void Deserialize(Reader reader)
		{
			ReqMsgId = reader.Read<long>();
			Info = reader.Read<byte[]>();

		}
	}
}