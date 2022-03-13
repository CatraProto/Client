using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedFile : CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase
	{


        public static int StaticConstructorId { get => 1248893260; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("size")]
		public int Size { get; set; }

[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("key_fingerprint")]
		public int KeyFingerprint { get; set; }


        #nullable enable
 public EncryptedFile (long id,long accessHash,int size,int dcId,int keyFingerprint)
{
 Id = id;
AccessHash = accessHash;
Size = size;
DcId = dcId;
KeyFingerprint = keyFingerprint;
 
}
#nullable disable
        internal EncryptedFile() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Size);
			writer.Write(DcId);
			writer.Write(KeyFingerprint);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Size = reader.Read<int>();
			DcId = reader.Read<int>();
			KeyFingerprint = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "encryptedFile";
		}
	}
}