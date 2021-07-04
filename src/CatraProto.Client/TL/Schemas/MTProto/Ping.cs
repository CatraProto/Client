using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Ping : IMethod
	{


        public static int ConstructorId { get; } = 2059302892;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.PongBase);
		public bool IsVector { get; init; } = false;
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