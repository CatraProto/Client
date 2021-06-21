using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsStateInfo : MsgsStateInfoBase
	{


        public static int ConstructorId { get; } = 81704317;
		public override long ReqMsgId { get; set; }
		public override byte[] Info { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ReqMsgId);
			writer.Write(Info);

		}

		public override void Deserialize(Reader reader)
		{
			ReqMsgId = reader.Read<long>();
			Info = reader.Read<byte[]>();

		}
	}
}