using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ResolveUsername : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResolvedPeerBase>
	{


        public static int ConstructorId { get; } = -113456221;

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