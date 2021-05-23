using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ResolveUsername : IMethod
	{


        public static int ConstructorId { get; } = -113456221;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResolveUsername);
		public bool IsVector { get; init; } = false;
		public string Username { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Username);

		}

		public void Deserialize(Reader reader)
		{
			Username = reader.Read<string>();

		}
	}
}