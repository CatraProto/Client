using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class FolderPeer : CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase
	{


        public static int StaticConstructorId { get => -373643672; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public sealed override int FolderId { get; set; }


        #nullable enable
 public FolderPeer (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,int folderId)
{
 Peer = peer;
FolderId = folderId;
 
}
#nullable disable
        internal FolderPeer() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(FolderId);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			FolderId = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "folderPeer";
		}
	}
}