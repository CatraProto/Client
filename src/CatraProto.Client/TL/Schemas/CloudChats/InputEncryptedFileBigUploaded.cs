using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputEncryptedFileBigUploaded : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase
	{


        public static int StaticConstructorId { get => 767652808; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public long Id { get; set; }

[JsonPropertyName("parts")]
		public int Parts { get; set; }

[JsonPropertyName("key_fingerprint")]
		public int KeyFingerprint { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}