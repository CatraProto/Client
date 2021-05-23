using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class FileCdnRedirect : FileBase
	{


        public static int ConstructorId { get; } = -242427324;
		public int DcId { get; set; }
		public byte[] FileToken { get; set; }
		public byte[] EncryptionKey { get; set; }
		public byte[] EncryptionIv { get; set; }
		public IList<FileHashBase> FileHashes { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(DcId);
			writer.Write(FileToken);
			writer.Write(EncryptionKey);
			writer.Write(EncryptionIv);
			writer.Write(FileHashes);

		}

		public override void Deserialize(Reader reader)
		{
			DcId = reader.Read<int>();
			FileToken = reader.Read<byte[]>();
			EncryptionKey = reader.Read<byte[]>();
			EncryptionIv = reader.Read<byte[]>();
			FileHashes = reader.ReadVector<FileHashBase>();

		}
	}
}