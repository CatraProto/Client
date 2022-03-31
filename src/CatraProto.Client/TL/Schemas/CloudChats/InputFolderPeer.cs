using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputFolderPeer : CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -70073706; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public sealed override int FolderId { get; set; }


        #nullable enable
 public InputFolderPeer (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int folderId)
{
 Peer = peer;
FolderId = folderId;
 
}
#nullable disable
        internal InputFolderPeer() 
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
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			FolderId = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "inputFolderPeer";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}