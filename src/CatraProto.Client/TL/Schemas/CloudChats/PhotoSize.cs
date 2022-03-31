using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1976012384; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public sealed override string Type { get; set; }

[Newtonsoft.Json.JsonProperty("w")]
		public int W { get; set; }

[Newtonsoft.Json.JsonProperty("h")]
		public int H { get; set; }

[Newtonsoft.Json.JsonProperty("size")]
		public int Size { get; set; }


        #nullable enable
 public PhotoSize (string type,int w,int h,int size)
{
 Type = type;
W = w;
H = h;
Size = size;
 
}
#nullable disable
        internal PhotoSize() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Size);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Size = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "photoSize";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}