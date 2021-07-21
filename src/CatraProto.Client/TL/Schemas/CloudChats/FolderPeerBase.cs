using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FolderPeerBase : IObject
    {

[JsonPropertyName("peer")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[JsonPropertyName("folder_id")]
		public abstract int FolderId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
