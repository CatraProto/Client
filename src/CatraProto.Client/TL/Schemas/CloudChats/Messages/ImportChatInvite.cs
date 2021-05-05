using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ImportChatInvite : IMethod<UpdatesBase>
	{


        public static int ConstructorId { get; } = 1817183516;

		public Type Type { get; init; } = typeof(ImportChatInvite);
		public bool IsVector { get; init; } = false;
		public string Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<string>();

		}
	}
}