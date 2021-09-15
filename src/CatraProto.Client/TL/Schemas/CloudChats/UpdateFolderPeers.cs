using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateFolderPeers : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 422972864; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("folder_peers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase> FolderPeers { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public int PtsCount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FolderPeers);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			FolderPeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateFolderPeers";
		}
	}
}