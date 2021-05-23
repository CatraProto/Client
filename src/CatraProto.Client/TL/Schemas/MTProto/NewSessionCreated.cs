using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class NewSessionCreated : IMethod
	{


        public static int ConstructorId { get; } = -1631450872;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.NewSessionCreated);
		public bool IsVector { get; init; } = false;
		public long FirstMsgId { get; set; }
		public long UniqueId { get; set; }
		public long ServerSalt { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FirstMsgId);
			writer.Write(UniqueId);
			writer.Write(ServerSalt);

		}

		public void Deserialize(Reader reader)
		{
			FirstMsgId = reader.Read<long>();
			UniqueId = reader.Read<long>();
			ServerSalt = reader.Read<long>();

		}
	}
}