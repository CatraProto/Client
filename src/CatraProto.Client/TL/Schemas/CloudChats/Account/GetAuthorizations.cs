using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetAuthorizations : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase>
	{


        public static int ConstructorId { get; } = -484392616;


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