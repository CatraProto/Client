using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SignUp : IMethod
	{


        public static int ConstructorId { get; } = -2131827673;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.SignUp);
		public bool IsVector { get; init; } = false;
		public string PhoneNumber { get; set; }
		public string PhoneCodeHash { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneNumber);
			writer.Write(PhoneCodeHash);
			writer.Write(FirstName);
			writer.Write(LastName);

		}

		public void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			PhoneCodeHash = reader.Read<string>();
			FirstName = reader.Read<string>();
			LastName = reader.Read<string>();

		}
	}
}