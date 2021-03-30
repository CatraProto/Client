using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class CheckPassword : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>
	{


        public static int ConstructorId { get; } = -779399914;

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