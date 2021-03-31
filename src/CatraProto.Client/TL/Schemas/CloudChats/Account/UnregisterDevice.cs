using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UnregisterDevice : IMethod<bool>
	{


        public static int ConstructorId { get; } = 813089983;

		public int TokenType { get; set; }
		public string Token { get; set; }
		public IList<int> OtherUids { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(TokenType);
			writer.Write(Token);
			writer.Write(OtherUids);

		}

		public void Deserialize(Reader reader)
		{
			TokenType = reader.Read<int>();
			Token = reader.Read<string>();
			OtherUids = reader.ReadVector<int>();

		}
	}
}