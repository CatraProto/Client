using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt64(VideoId);
var checkcaption = 			writer.WriteObject(Caption);
if(checkcaption.IsError){
 return checkcaption; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			Autoplay = FlagsHelper.IsFlagSet(Flags, 0);
			Loop = FlagsHelper.IsFlagSet(Flags, 1);
			var tryvideoId = reader.ReadInt64();
if(tryvideoId.IsError){
return ReadResult<IObject>.Move(tryvideoId);
}
VideoId = tryvideoId.Value;
			var trycaption = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
if(trycaption.IsError){
return ReadResult<IObject>.Move(trycaption);
}
Caption = trycaption.Value;
return new ReadResult<IObject>(this);

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