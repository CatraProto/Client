using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class CheckPassword : IMethod
	{


        public static int ConstructorId { get; } = -779399914;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }

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
			Password = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();

		}
	}
}