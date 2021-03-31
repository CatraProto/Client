using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
	public partial class EditPeerFolders : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{


        public static int ConstructorId { get; } = 1749536939;

		public IList<InputFolderPeerBase> FolderPeers { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FolderPeers);

		}

		public void Deserialize(Reader reader)
		{
			FolderPeers = reader.ReadVector<InputFolderPeerBase>();

		}
	}
}