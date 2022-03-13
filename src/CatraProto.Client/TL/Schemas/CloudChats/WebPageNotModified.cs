using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebPageNotModified : CatraProto.Client.TL.Schemas.CloudChats.WebPageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CachedPageViews = 1 << 0
		}

        public static int StaticConstructorId { get => 1930545681; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("cached_page_views")]
		public int? CachedPageViews { get; set; }


        
        public WebPageNotModified() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = CachedPageViews == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(CachedPageViews.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				CachedPageViews = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "webPageNotModified";
		}
	}
}