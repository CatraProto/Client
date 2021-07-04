using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ResetTopPeerRating : IMethod
	{


        public static int ConstructorId { get; } = 451113900;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

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
			Category = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase>();
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();

		}
	}
}