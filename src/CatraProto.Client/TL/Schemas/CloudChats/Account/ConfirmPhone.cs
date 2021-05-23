using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ConfirmPhone : IMethod
	{


        public static int ConstructorId { get; } = 1596029123;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.ConfirmPhone);
		public bool IsVector { get; init; } = false;
		public string PhoneCodeHash { get; set; }
		public string PhoneCode { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneCodeHash);
			writer.Write(PhoneCode);

		}

		public void Deserialize(Reader reader)
		{
			PhoneCodeHash = reader.Read<string>();
			PhoneCode = reader.Read<string>();

		}
	}
}