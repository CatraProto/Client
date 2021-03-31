using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetAuthorizationForm : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase>
	{


        public static int ConstructorId { get; } = -1200903967;

		public int BotId { get; set; }
		public string Scope { get; set; }
		public string PublicKey { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BotId);
			writer.Write(Scope);
			writer.Write(PublicKey);

		}

		public void Deserialize(Reader reader)
		{
			BotId = reader.Read<int>();
			Scope = reader.Read<string>();
			PublicKey = reader.Read<string>();

		}
	}
}