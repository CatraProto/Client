using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AcceptEncryption : IMethod
	{


        public static int ConstructorId { get; } = 1035731989;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }
		public byte[] GB { get; set; }
		public long KeyFingerprint { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(GB);
			writer.Write(KeyFingerprint);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
			GB = reader.Read<byte[]>();
			KeyFingerprint = reader.Read<long>();

		}
	}
}