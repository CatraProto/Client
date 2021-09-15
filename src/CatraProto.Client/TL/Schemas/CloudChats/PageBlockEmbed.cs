using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockEmbed : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FullWidth = 1 << 0,
			AllowScrolling = 1 << 3,
			Url = 1 << 1,
			Html = 1 << 2,
			PosterPhotoId = 1 << 4,
			W = 1 << 5,
			H = 1 << 5
		}

        public static int StaticConstructorId { get => -1468953147; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("full_width")]
		public bool FullWidth { get; set; }

[Newtonsoft.Json.JsonProperty("allow_scrolling")]
		public bool AllowScrolling { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("html")]
		public string Html { get; set; }

[Newtonsoft.Json.JsonProperty("poster_photo_id")]
		public long? PosterPhotoId { get; set; }

[Newtonsoft.Json.JsonProperty("w")]
		public int? W { get; set; }

[Newtonsoft.Json.JsonProperty("h")]
		public int? H { get; set; }

[Newtonsoft.Json.JsonProperty("caption")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = FullWidth ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = AllowScrolling ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Html == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = PosterPhotoId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = W == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
			Flags = H == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Url);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Html);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(PosterPhotoId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(W.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(H.Value);
			}

			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			FullWidth = FlagsHelper.IsFlagSet(Flags, 0);
			AllowScrolling = FlagsHelper.IsFlagSet(Flags, 3);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Url = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Html = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				PosterPhotoId = reader.Read<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				W = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				H = reader.Read<int>();
			}

			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();

		}
				
		public override string ToString()
		{
		    return "pageBlockEmbed";
		}
	}
}