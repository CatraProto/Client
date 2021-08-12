using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class UploadProfilePhoto : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			File = 1 << 0,
			Video = 1 << 1,
			VideoStartTs = 1 << 2
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1980559511; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(PhotoBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("file")]
		public InputFileBase File { get; set; }

[JsonPropertyName("video")]
		public InputFileBase Video { get; set; }

[JsonPropertyName("video_start_ts")]
		public double? VideoStartTs { get; set; }


		public void UpdateFlags() 
		{
			Flags = File == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Video == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = VideoStartTs == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(File);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Video);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(VideoStartTs);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				File = reader.Read<InputFileBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Video = reader.Read<InputFileBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				VideoStartTs = reader.Read<double>();
			}
		}

		public override string ToString()
		{
			return "photos.uploadProfilePhoto";
		}
	}
}