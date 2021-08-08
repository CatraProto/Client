using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class FileCdnRedirect : FileBase
	{


        public static int StaticConstructorId { get => -242427324; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("dc_id")]
		public int DcId { get; set; }

[JsonPropertyName("file_token")]
		public byte[] FileToken { get; set; }

[JsonPropertyName("encryption_key")]
		public byte[] EncryptionKey { get; set; }

[JsonPropertyName("encryption_iv")]
		public byte[] EncryptionIv { get; set; }

[JsonPropertyName("file_hashes")]
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