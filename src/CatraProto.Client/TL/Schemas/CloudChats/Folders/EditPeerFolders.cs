using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
	public partial class EditPeerFolders : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1749536939; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("folder_peers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase> FolderPeers { get; set; }

        
        #nullable enable
 public EditPeerFolders (IList<CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase> folderPeers)
{
 FolderPeers = folderPeers;
 
}
#nullable disable
                
        internal EditPeerFolders() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(FolderPeers);

		}

		public void Deserialize(Reader reader)
		{
			FolderPeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase>();

		}

		public override string ToString()
		{
		    return "folders.editPeerFolders";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}