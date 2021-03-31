using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SendVerifyEmailCode : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase>
	{


        public static int ConstructorId { get; } = 1880182943;

		public string Email { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Email);

		}

		public void Deserialize(Reader reader)
		{
			Email = reader.Read<string>();

		}
	}
}