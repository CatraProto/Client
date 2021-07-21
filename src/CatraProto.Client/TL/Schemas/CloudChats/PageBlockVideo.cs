using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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

        public static int StaticConstructorId { get => 2089805750; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("autoplay")]
		public bool Autoplay { get; set; }

[JsonPropertyName("loop")]
		public bool Loop { get; set; }

[JsonPropertyName("video_id")]
		public long VideoId { get; set; }

[JsonPropertyName("caption")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Autoplay ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Loop ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}