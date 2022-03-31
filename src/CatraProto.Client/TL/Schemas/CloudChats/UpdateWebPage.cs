using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateWebPage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2139689491; }
        
[Newtonsoft.Json.JsonProperty("webpage")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebPageBase Webpage { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public int PtsCount { get; set; }


        #nullable enable
 public UpdateWebPage (CatraProto.Client.TL.Schemas.CloudChats.WebPageBase webpage,int pts,int ptsCount)
{
 Webpage = webpage;
Pts = pts;
PtsCount = ptsCount;
 
}
#nullable disable
        internal UpdateWebPage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Webpage);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Webpage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateWebPage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}