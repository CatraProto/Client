using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureSecretSettings : SecureSecretSettingsBase
	{


        public static int ConstructorId { get; } = 354925740;
		public override CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase SecureAlgo { get; set; }
		public override byte[] SecureSecret { get; set; }
		public override long SecureSecretId { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(SecureAlgo);
			writer.Write(SecureSecret);
			writer.Write(SecureSecretId);

		}

		public override void Deserialize(Reader reader)
		{
			SecureAlgo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase>();
			SecureSecret = reader.Read<byte[]>();
			SecureSecretId = reader.Read<long>();

		}
	}
}