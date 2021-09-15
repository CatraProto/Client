using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class FileCdnRedirect : CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase
	{


        public static int StaticConstructorId { get => -242427324; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("file_token")]
		public byte[] FileToken { get; set; }

[Newtonsoft.Json.JsonProperty("encryption_key")]
		public byte[] EncryptionKey { get; set; }

[Newtonsoft.Json.JsonProperty("encryption_iv")]
		public byte[] EncryptionIv { get; set; }

[Newtonsoft.Json.JsonProperty("file_hashes")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase> FileHashes { get; set; }

        
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
			FileHashes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>();

		}
				
		public override string ToString()
		{
		    return "upload.fileCdnRedirect";
		}
	}
}