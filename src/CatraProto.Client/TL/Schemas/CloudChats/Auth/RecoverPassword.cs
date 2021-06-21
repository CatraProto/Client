using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class RecoverPassword : IMethod
	{


        public static int ConstructorId { get; } = 1319464594;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase);
		public bool IsVector { get; init; } = false;
		public string Code { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Code);

		}

		public void Deserialize(Reader reader)
		{
			Code = reader.Read<string>();

		}
	}
}