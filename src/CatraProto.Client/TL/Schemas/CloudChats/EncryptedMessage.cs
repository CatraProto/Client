using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedMessage : EncryptedMessageBase
	{


        public static int ConstructorId { get; } = -317144808;
		public override long RandomId { get; set; }
		public override int ChatId { get; set; }
		public override int Date { get; set; }
		public override byte[] Bytes { get; set; }
		public EncryptedFileBase File { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(RandomId);
			writer.Write(ChatId);
			writer.Write(Date);
			writer.Write(Bytes);
			writer.Write(File);

		}

		public override void Deserialize(Reader reader)
		{
			RandomId = reader.Read<long>();
			ChatId = reader.Read<int>();
			Date = reader.Read<int>();
			Bytes = reader.Read<byte[]>();
			File = reader.Read<EncryptedFileBase>();

		}
	}
}