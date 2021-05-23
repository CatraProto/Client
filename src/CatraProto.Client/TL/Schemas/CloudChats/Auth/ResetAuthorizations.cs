using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ResetAuthorizations : IMethod
	{


        public static int ConstructorId { get; } = -1616179942;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.ResetAuthorizations);
		public bool IsVector { get; init; } = false;

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