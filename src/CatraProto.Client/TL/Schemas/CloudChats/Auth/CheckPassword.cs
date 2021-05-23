using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class CheckPassword : IMethod
	{


        public static int ConstructorId { get; } = -779399914;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.CheckPassword);
		public bool IsVector { get; init; } = false;
		public InputCheckPasswordSRPBase Password { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Password);

		}

		public void Deserialize(Reader reader)
		{
			Password = reader.Read<InputCheckPasswordSRPBase>();

		}
	}
}