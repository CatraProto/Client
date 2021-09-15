using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class File : CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase
	{


        public static int StaticConstructorId { get => 157948117; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("mtime")]
		public int Mtime { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
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
				
		public override string ToString()
		{
		    return "upload.file";
		}
	}
}