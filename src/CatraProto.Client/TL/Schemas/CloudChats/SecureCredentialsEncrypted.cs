using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureCredentialsEncrypted : SecureCredentialsEncryptedBase
	{


        public static int ConstructorId { get; } = 871426631;
		public override byte[] Data { get; set; }
		public override byte[] Hash { get; set; }
		public override byte[] Secret { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Data);
			writer.Write(Hash);
			writer.Write(Secret);

		}

		public override void Deserialize(Reader reader)
		{
			Data = reader.Read<byte[]>();
			Hash = reader.Read<byte[]>();
			Secret = reader.Read<byte[]>();

		}
	}
}