using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RecentMeUrlStickerSet : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
	{


        public static int StaticConstructorId { get => -1140172836; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("set")]
		public CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase Set { get; set; }


        #nullable enable
 public RecentMeUrlStickerSet (string url,CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase set)
{
 Url = url;
Set = set;
 
}
#nullable disable
        internal RecentMeUrlStickerSet() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(Set);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			Set = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();

		}
				
		public override string ToString()
		{
		    return "recentMeUrlStickerSet";
		}
	}
}