using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class NewSessionCreated : IMethod<CatraProto.Client.TL.Schemas.MTProto.NewSessionBase>
	{


        public static int ConstructorId { get; } = -1631450872;

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