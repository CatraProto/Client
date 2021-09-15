using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoCachedSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
	{


        public static int StaticConstructorId { get => -374917894; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public override string Type { get; set; }

[Newtonsoft.Json.JsonProperty("location")]
		public CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase Location { get; set; }

[Newtonsoft.Json.JsonProperty("w")]
		public int W { get; set; }

[Newtonsoft.Json.JsonProperty("h")]
		public int H { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
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
				
		public override string ToString()
		{
		    return "photoCachedSize";
		}
	}
}