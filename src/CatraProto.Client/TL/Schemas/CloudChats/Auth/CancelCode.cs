using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class CancelCode : IMethod<bool>
	{


        public static int ConstructorId { get; } = 520357240;

		public string PhoneNumber { get; set; }
		public string PhoneCodeHash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneNumber);
			writer.Write(PhoneCodeHash);

		}

		public void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			PhoneCodeHash = reader.Read<string>();

		}
	}
}