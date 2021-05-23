using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class BindTempAuthKey : IMethod
	{


        public static int ConstructorId { get; } = -841733627;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.BindTempAuthKey);
		public bool IsVector { get; init; } = false;
		public long PermAuthKeyId { get; set; }
		public long Nonce { get; set; }
		public int ExpiresAt { get; set; }
		public byte[] EncryptedMessage { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PermAuthKeyId);
			writer.Write(Nonce);
			writer.Write(ExpiresAt);
			writer.Write(EncryptedMessage);

		}

		public void Deserialize(Reader reader)
		{
			PermAuthKeyId = reader.Read<long>();
			Nonce = reader.Read<long>();
			ExpiresAt = reader.Read<int>();
			EncryptedMessage = reader.Read<byte[]>();

		}
	}
}