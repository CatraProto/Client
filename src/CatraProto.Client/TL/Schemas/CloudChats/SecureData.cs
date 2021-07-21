using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureData : CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase
	{


        public static int StaticConstructorId { get => -1964327229; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("data")]
		public override byte[] Data { get; set; }

[JsonPropertyName("data_hash")]
		public override byte[] DataHash { get; set; }

[JsonPropertyName("secret")]
		public override byte[] Secret { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Data);
			writer.Write(DataHash);
			writer.Write(Secret);

		}

		public override void Deserialize(Reader reader)
		{
			Data = reader.Read<byte[]>();
			DataHash = reader.Read<byte[]>();
			Secret = reader.Read<byte[]>();

		}
	}
}