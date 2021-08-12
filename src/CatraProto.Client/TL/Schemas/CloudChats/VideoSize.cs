using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class VideoSize : VideoSizeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			VideoStartTs = 1 << 0
		}

        public static int StaticConstructorId { get => -399391402; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("type")]
		public override string Type { get; set; }

[JsonPropertyName("location")]
		public override FileLocationBase Location { get; set; }

[JsonPropertyName("w")]
		public override int W { get; set; }

[JsonPropertyName("h")]
		public override int H { get; set; }

[JsonPropertyName("size")]
		public override int Size { get; set; }

[JsonPropertyName("video_start_ts")]
		public override double? VideoStartTs { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = VideoStartTs == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Type);
			writer.Write(Location);
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
			Location = reader.Read<FileLocationBase>();
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
	}
}