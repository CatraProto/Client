using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Ping : IMethod<CatraProto.Client.TL.Schemas.MTProto.PongBase>
	{


        public static int ConstructorId { get; } = 2059302892;

		public long PingId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PingId);

		}

		public void Deserialize(Reader reader)
		{
			PingId = reader.Read<long>();

		}
	}
}