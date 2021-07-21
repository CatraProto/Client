using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class File : CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase
	{


        public static int StaticConstructorId { get => 157948117; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("type")]
		public CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase Type { get; set; }

[JsonPropertyName("mtime")]
		public int Mtime { get; set; }

[JsonPropertyName("bytes")]
		public byte[] Bytes { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Mtime);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase>();
			Mtime = reader.Read<int>();
			Bytes = reader.Read<byte[]>();

		}
	}
}