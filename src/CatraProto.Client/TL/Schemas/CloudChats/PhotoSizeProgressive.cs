using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoSizeProgressive : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
	{


        public static int StaticConstructorId { get => -96535659; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public sealed override string Type { get; set; }

[Newtonsoft.Json.JsonProperty("w")]
		public int W { get; set; }

[Newtonsoft.Json.JsonProperty("h")]
		public int H { get; set; }

[Newtonsoft.Json.JsonProperty("sizes")]
		public IList<int> Sizes { get; set; }


        #nullable enable
 public PhotoSizeProgressive (string type,int w,int h,IList<int> sizes)
{
 Type = type;
W = w;
H = h;
Sizes = sizes;
 
}
#nullable disable
        internal PhotoSizeProgressive() 
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
			writer.Write(Sizes);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Sizes = reader.ReadVector<int>();

		}
				
		public override string ToString()
		{
		    return "photoSizeProgressive";
		}
	}
}