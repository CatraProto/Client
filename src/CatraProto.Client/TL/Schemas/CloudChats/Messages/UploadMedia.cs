using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UploadMedia : IMethod
	{


        public static int ConstructorId { get; } = 1369162417;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Media);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();

		}
	}
}