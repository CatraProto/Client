using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DocumentAttributeImageSize : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1815593308; }
        
[Newtonsoft.Json.JsonProperty("w")]
		public int W { get; set; }

[Newtonsoft.Json.JsonProperty("h")]
		public int H { get; set; }


        #nullable enable
 public DocumentAttributeImageSize (int w,int h)
{
 W = w;
H = h;
 
}
#nullable disable
        internal DocumentAttributeImageSize() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(W);
			writer.Write(H);

		}

		public override void Deserialize(Reader reader)
		{
			W = reader.Read<int>();
			H = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "documentAttributeImageSize";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}