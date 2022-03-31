using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputEncryptedFileUploaded : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1690108678; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("parts")]
		public int Parts { get; set; }

[Newtonsoft.Json.JsonProperty("md5_checksum")]
		public string Md5Checksum { get; set; }

[Newtonsoft.Json.JsonProperty("key_fingerprint")]
		public int KeyFingerprint { get; set; }


        #nullable enable
 public InputEncryptedFileUploaded (long id,int parts,string md5Checksum,int keyFingerprint)
{
 Id = id;
Parts = parts;
Md5Checksum = md5Checksum;
KeyFingerprint = keyFingerprint;
 
}
#nullable disable
        internal InputEncryptedFileUploaded() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Parts);
			writer.Write(Md5Checksum);
			writer.Write(KeyFingerprint);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Parts = reader.Read<int>();
			Md5Checksum = reader.Read<string>();
			KeyFingerprint = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "inputEncryptedFileUploaded";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}