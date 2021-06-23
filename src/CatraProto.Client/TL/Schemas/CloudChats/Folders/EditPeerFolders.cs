using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
	public partial class EditPeerFolders : IMethod
	{
		public static int ConstructorId { get; } = 1749536939;
		public IList<InputFolderPeerBase> FolderPeers { get; set; }

		public Type Type { get; init; } = typeof(UpdatesBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(FolderPeers);
		}

		public void Deserialize(Reader reader)
		{
			FolderPeers = reader.ReadVector<InputFolderPeerBase>();
		}
	}
}