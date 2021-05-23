using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Authorizations : AuthorizationsBase
	{


        public static int ConstructorId { get; } = 307276766;
		public override IList<AuthorizationBase> PAuthorizations { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PAuthorizations);

		}

		public override void Deserialize(Reader reader)
		{
			PAuthorizations = reader.ReadVector<AuthorizationBase>();

		}
	}
}