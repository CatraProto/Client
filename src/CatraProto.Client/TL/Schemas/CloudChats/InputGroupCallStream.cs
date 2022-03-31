using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputGroupCallStream : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			VideoChannel = 1 << 0,
			VideoQuality = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 93890858; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("time_ms")]
		public long TimeMs { get; set; }

[Newtonsoft.Json.JsonProperty("scale")]
		public int Scale { get; set; }

[Newtonsoft.Json.JsonProperty("video_channel")]
		public int? VideoChannel { get; set; }

[Newtonsoft.Json.JsonProperty("video_quality")]
		public int? VideoQuality { get; set; }


        #nullable enable
 public InputGroupCallStream (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call,long timeMs,int scale)
{
 Call = call;
TimeMs = timeMs;
Scale = scale;
 
}
#nullable disable
        internal InputGroupCallStream() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = VideoChannel == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = VideoQuality == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Call);
			writer.Write(TimeMs);
			writer.Write(Scale);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(VideoChannel.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(VideoQuality.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			TimeMs = reader.Read<long>();
			Scale = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				VideoChannel = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				VideoQuality = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "inputGroupCallStream";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}