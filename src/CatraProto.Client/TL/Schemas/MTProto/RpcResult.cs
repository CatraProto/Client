using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcResult : IMethod<CatraProto.Client.TL.Schemas.MTProto.RpcResultBase>
	{


        public static int ConstructorId { get; } = -212046591;

		public long ReqMsgId { get; set; }
		public IObject Result { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ReqMsgId);
			writer.Write(Result);

		}

		public void Deserialize(Reader reader)
		{
			ReqMsgId = reader.Read<long>();
			Result = reader.Read<IObject>();

		}
	}
}