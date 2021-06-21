using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcDropAnswer : IMethod
	{
		public static int ConstructorId { get; } = 1491380032;
		public long ReqMsgId { get; set; }

		public Type Type { get; init; } = typeof(RpcDropAnswerBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ReqMsgId);
		}

		public void Deserialize(Reader reader)
		{
			ReqMsgId = reader.Read<long>();
		}
	}
}