using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputEncryptedFileBigUploaded : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase
	{


        public static int StaticConstructorId { get => 767652808; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("parts")]
		public int Parts { get; set; }

[Newtonsoft.Json.JsonProperty("key_fingerprint")]
		public int KeyFingerprint { get; set; }


        #nullable enable
 public InputEncryptedFileBigUploaded (long id,int parts,int keyFingerprint)
{
 Id = id;
Parts = parts;
KeyFingerprint = keyFingerprint;
 
}
#nullable disable
        internal InputEncryptedFileBigUploaded() 
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
			writer.Write(KeyFingerprint);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Parts = reader.Read<int>();
			KeyFingerprint = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "inputEncryptedFileBigUploaded";
		}
	}
}