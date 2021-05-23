using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class LoginTokenSuccess : LoginTokenBase
	{


        public static int ConstructorId { get; } = 957176926;
		public AuthorizationBase Authorization { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Authorization);

		}

		public override void Deserialize(Reader reader)
		{
			Authorization = reader.Read<AuthorizationBase>();

		}
	}
}