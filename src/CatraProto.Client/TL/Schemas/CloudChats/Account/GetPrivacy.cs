using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetPrivacy : IMethod
	{


        public static int ConstructorId { get; } = -623130288;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.GetPrivacy);
		public bool IsVector { get; init; } = false;
		public InputPrivacyKeyBase Key { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Key);

		}

		public void Deserialize(Reader reader)
		{
			Key = reader.Read<InputPrivacyKeyBase>();

		}
	}
}