using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PingDelayDisconnect : IMethod<CatraProto.Client.TL.Schemas.MTProto.PongBase>
	{


        public static int ConstructorId { get; } = -213746804;

		public long PingId { get; set; }
		public int DisconnectDelay { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PingId);
			writer.Write(DisconnectDelay);

		}

		public void Deserialize(Reader reader)
		{
			PingId = reader.Read<long>();
			DisconnectDelay = reader.Read<int>();

		}
	}
}