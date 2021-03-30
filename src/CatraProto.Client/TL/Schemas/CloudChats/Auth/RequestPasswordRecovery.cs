using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class RequestPasswordRecovery : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecoveryBase>
	{


        public static int ConstructorId { get; } = -661144474;


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}