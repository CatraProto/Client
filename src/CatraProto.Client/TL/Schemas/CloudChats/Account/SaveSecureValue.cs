using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveSecureValue : IMethod
	{


        public static int ConstructorId { get; } = -1986010339;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase Value { get; set; }
		public long SecureSecretId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Value);
			writer.Write(SecureSecretId);

		}

		public void Deserialize(Reader reader)
		{
			Value = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase>();
			SecureSecretId = reader.Read<long>();

		}
	}
}