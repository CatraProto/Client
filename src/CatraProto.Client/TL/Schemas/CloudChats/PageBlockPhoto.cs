using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockPhoto : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Url = 1 << 0,
			WebpageId = 1 << 0
		}

        public static int StaticConstructorId { get => 391759200; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("photo_id")]
		public long PhotoId { get; set; }

[Newtonsoft.Json.JsonProperty("caption")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("webpage_id")]
		public long? WebpageId { get; set; }


        #nullable enable
 public PageBlockPhoto (long photoId,CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
{
 PhotoId = photoId;
Caption = caption;
 
}
#nullable disable
        internal PageBlockPhoto() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = WebpageId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PhotoId);
			writer.Write(Caption);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Url);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(WebpageId.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			PhotoId = reader.Read<long>();
			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Url = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				WebpageId = reader.Read<long>();
			}


		}
				
		public override string ToString()
		{
		    return "pageBlockPhoto";
		}
	}
}