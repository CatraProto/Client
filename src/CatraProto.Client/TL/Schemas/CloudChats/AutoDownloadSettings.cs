using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class AutoDownloadSettings : AutoDownloadSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Disabled = 1 << 0,
			VideoPreloadLarge = 1 << 1,
			AudioPreloadNext = 1 << 2,
			PhonecallsLessData = 1 << 3
		}

        public static int StaticConstructorId { get => -532532493; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("disabled")]
		public override bool Disabled { get; set; }

[JsonPropertyName("video_preload_large")]
		public override bool VideoPreloadLarge { get; set; }

[JsonPropertyName("audio_preload_next")]
		public override bool AudioPreloadNext { get; set; }

[JsonPropertyName("phonecalls_less_data")]
		public override bool PhonecallsLessData { get; set; }

[JsonPropertyName("photo_size_max")]
		public override int PhotoSizeMax { get; set; }

[JsonPropertyName("video_size_max")]
		public override int VideoSizeMax { get; set; }

[JsonPropertyName("file_size_max")]
		public override int FileSizeMax { get; set; }

[JsonPropertyName("video_upload_maxbitrate")]
		public override int VideoUploadMaxbitrate { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Disabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = VideoPreloadLarge ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = AudioPreloadNext ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = PhonecallsLessData ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PhotoSizeMax);
			writer.Write(VideoSizeMax);
			writer.Write(FileSizeMax);
			writer.Write(VideoUploadMaxbitrate);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Disabled = FlagsHelper.IsFlagSet(Flags, 0);
			VideoPreloadLarge = FlagsHelper.IsFlagSet(Flags, 1);
			AudioPreloadNext = FlagsHelper.IsFlagSet(Flags, 2);
			PhonecallsLessData = FlagsHelper.IsFlagSet(Flags, 3);
			PhotoSizeMax = reader.Read<int>();
			VideoSizeMax = reader.Read<int>();
			FileSizeMax = reader.Read<int>();
			VideoUploadMaxbitrate = reader.Read<int>();

		}
	}
}