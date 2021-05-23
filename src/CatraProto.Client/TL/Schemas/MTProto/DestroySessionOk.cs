using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DestroySessionOk : IMethod
	{


        public static int ConstructorId { get; } = -501201412;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.DestroySessionOk);
		public bool IsVector { get; init; } = false;
		public long SessionId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(SessionId);

		}

		public void Deserialize(Reader reader)
		{
			SessionId = reader.Read<long>();

		}
	}
}