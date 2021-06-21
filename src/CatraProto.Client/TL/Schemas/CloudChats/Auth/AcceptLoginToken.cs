using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class AcceptLoginToken : IMethod
	{


        public static int ConstructorId { get; } = -392909491;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase);
		public bool IsVector { get; init; } = false;
		public byte[] Token { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Token);

		}

		public void Deserialize(Reader reader)
		{
			Token = reader.Read<byte[]>();

		}
	}
}