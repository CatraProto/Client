using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class FolderPeer : FolderPeerBase
	{


        public static int StaticConstructorId { get => -373643672; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer")]
		public override PeerBase Peer { get; set; }

[JsonPropertyName("folder_id")]
		public override int FolderId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(FolderId);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<PeerBase>();
			FolderId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "folderPeer";
		}
	}
}