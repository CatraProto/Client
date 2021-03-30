using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UploadEncryptedFile : IMethod<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>
	{


        public static int ConstructorId { get; } = 1347929239;

		public InputEncryptedChatBase Peer { get; set; }
		public InputEncryptedFileBase File { get; set; }

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
			Peer = reader.Read<InputEncryptedChatBase>();
			File = reader.Read<InputEncryptedFileBase>();

		}
	}
}