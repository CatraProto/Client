using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputSecureFileUploaded : CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase
	{


        public static int StaticConstructorId { get => 859091184; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("parts")]
		public int Parts { get; set; }

[Newtonsoft.Json.JsonProperty("md5_checksum")]
		public string Md5Checksum { get; set; }

[Newtonsoft.Json.JsonProperty("file_hash")]
		public byte[] FileHash { get; set; }

[Newtonsoft.Json.JsonProperty("secret")]
		public byte[] Secret { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Parts);
			writer.Write(Md5Checksum);
			writer.Write(FileHash);
			writer.Write(Secret);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Parts = reader.Read<int>();
			Md5Checksum = reader.Read<string>();
			FileHash = reader.Read<byte[]>();
			Secret = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "inputSecureFileUploaded";
		}
	}
}