using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetPinnedDialogs : IMethod<PeerDialogsBase>
	{


        public static int ConstructorId { get; } = -692498958;

		public Type Type { get; init; } = typeof(GetPinnedDialogs);
		public bool IsVector { get; init; } = false;
		public int FolderId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FolderId);

		}

		public void Deserialize(Reader reader)
		{
			FolderId = reader.Read<int>();

		}
	}
}