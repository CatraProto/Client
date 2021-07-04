using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SentEncryptedFile : SentEncryptedMessageBase
	{


        public static int ConstructorId { get; } = -1802240206;
		public override int Date { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase File { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Date);
			writer.Write(File);

		}

		public override void Deserialize(Reader reader)
		{
			Date = reader.Read<int>();
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>();

		}
	}
}