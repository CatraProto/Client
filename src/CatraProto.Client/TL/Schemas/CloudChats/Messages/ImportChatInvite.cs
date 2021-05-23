using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ImportChatInvite : IMethod
	{


        public static int ConstructorId { get; } = 1817183516;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ImportChatInvite);
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