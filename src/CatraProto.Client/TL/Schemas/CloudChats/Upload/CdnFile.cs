using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class CdnFile : CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase
	{


        public static int StaticConstructorId { get => -1449145777; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("bytes")]
		public byte[] Bytes { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			Bytes = reader.Read<byte[]>();

		}
	}
}