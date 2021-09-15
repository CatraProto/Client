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


        public static int StaticConstructorId { get => 1690108678; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("parts")]
		public int Parts { get; set; }

[Newtonsoft.Json.JsonProperty("md5_checksum")]
		public string Md5Checksum { get; set; }

[Newtonsoft.Json.JsonProperty("key_fingerprint")]
		public int KeyFingerprint { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}