using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Pong : IMethod<PongBase>
	{


        public static int ConstructorId { get; } = 880243653;

		public Type Type { get; init; } = typeof(Pong);
		public bool IsVector { get; init; } = false;
		public long MsgId { get; set; }
		public long PingId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(PingId);

		}

		public void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			PingId = reader.Read<long>();

		}
	}
}