using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class VideoSize : CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			VideoStartTs = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -567037804; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public sealed override string Type { get; set; }

[Newtonsoft.Json.JsonProperty("w")]
		public sealed override int W { get; set; }

[Newtonsoft.Json.JsonProperty("h")]
		public sealed override int H { get; set; }

[Newtonsoft.Json.JsonProperty("size")]
		public sealed override int Size { get; set; }

[Newtonsoft.Json.JsonProperty("video_start_ts")]
		public sealed override double? VideoStartTs { get; set; }


        #nullable enable
 public VideoSize (string type,int w,int h,int size)
{
 Type = type;
W = w;
H = h;
Size = size;
 
}
#nullable disable
        internal VideoSize() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = VideoStartTs == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Type);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Size);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(VideoStartTs);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Type = reader.Read<string>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Size = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				VideoStartTs = reader.Read<double>();
			}


		}
		
		public override string ToString()
		{
		    return "videoSize";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}