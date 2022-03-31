using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockVideo : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Autoplay = 1 << 0,
			Loop = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2089805750; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("autoplay")]
		public bool Autoplay { get; set; }

[Newtonsoft.Json.JsonProperty("loop")]
		public bool Loop { get; set; }

[Newtonsoft.Json.JsonProperty("video_id")]
		public long VideoId { get; set; }

[Newtonsoft.Json.JsonProperty("caption")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


        #nullable enable
 public PageBlockVideo (long videoId,CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
{
 VideoId = videoId;
Caption = caption;
 
}
#nullable disable
        internal PageBlockVideo() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Autoplay ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Loop ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(VideoId);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Autoplay = FlagsHelper.IsFlagSet(Flags, 0);
			Loop = FlagsHelper.IsFlagSet(Flags, 1);
			VideoId = reader.Read<long>();
			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();

		}
		
		public override string ToString()
		{
		    return "pageBlockVideo";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}