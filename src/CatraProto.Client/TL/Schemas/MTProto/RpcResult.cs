using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcResult : IMethod<RpcResultBase>
	{


        public static int ConstructorId { get; } = -212046591;

		public Type Type { get; init; } = typeof(RpcResult);
		public bool IsVector { get; init; } = false;
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