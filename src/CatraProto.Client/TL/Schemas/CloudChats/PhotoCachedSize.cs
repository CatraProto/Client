using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoCachedSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
	{


        public static int StaticConstructorId { get => -374917894; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("type")]
		public override string Type { get; set; }

[JsonPropertyName("location")]
		public CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase Location { get; set; }

[JsonPropertyName("w")]
		public int W { get; set; }

[JsonPropertyName("h")]
		public int H { get; set; }

[JsonPropertyName("bytes")]
		public byte[] Bytes { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Location);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
			Location = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Bytes = reader.Read<byte[]>();

		}
	}
}