using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoStrippedSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
	{


        public static int StaticConstructorId { get => -525288402; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public sealed override string Type { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public byte[] Bytes { get; set; }


        #nullable enable
 public PhotoStrippedSize (string type,byte[] bytes)
{
 Type = type;
Bytes = bytes;
 
}
#nullable disable
        internal PhotoStrippedSize() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
			Bytes = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "photoStrippedSize";
		}
	}
}