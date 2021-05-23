using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ResetTopPeerRating : IMethod
	{


        public static int ConstructorId { get; } = 451113900;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResetTopPeerRating);
		public bool IsVector { get; init; } = false;
		public TopPeerCategoryBase Category { get; set; }
		public InputPeerBase Peer { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Category);
			writer.Write(Peer);

		}

		public void Deserialize(Reader reader)
		{
			Category = reader.Read<TopPeerCategoryBase>();
			Peer = reader.Read<InputPeerBase>();

		}
	}
}