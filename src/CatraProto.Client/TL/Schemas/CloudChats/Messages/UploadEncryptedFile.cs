using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UploadEncryptedFile : IMethod
	{


        public static int ConstructorId { get; } = 1347929239;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase File { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(File);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase>();

		}
	}
}