using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class AutoDownloadSettings : CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Disabled = 1 << 0,
			VideoPreloadLarge = 1 << 1,
			AudioPreloadNext = 1 << 2,
			PhonecallsLessData = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -532532493; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("disabled")]
		public sealed override bool Disabled { get; set; }

[Newtonsoft.Json.JsonProperty("video_preload_large")]
		public sealed override bool VideoPreloadLarge { get; set; }

[Newtonsoft.Json.JsonProperty("audio_preload_next")]
		public sealed override bool AudioPreloadNext { get; set; }

[Newtonsoft.Json.JsonProperty("phonecalls_less_data")]
		public sealed override bool PhonecallsLessData { get; set; }

[Newtonsoft.Json.JsonProperty("photo_size_max")]
		public sealed override int PhotoSizeMax { get; set; }

[Newtonsoft.Json.JsonProperty("video_size_max")]
		public sealed override int VideoSizeMax { get; set; }

[Newtonsoft.Json.JsonProperty("file_size_max")]
		public sealed override int FileSizeMax { get; set; }

[Newtonsoft.Json.JsonProperty("video_upload_maxbitrate")]
		public sealed override int VideoUploadMaxbitrate { get; set; }


        #nullable enable
 public AutoDownloadSettings (int photoSizeMax,int videoSizeMax,int fileSizeMax,int videoUploadMaxbitrate)
{
 PhotoSizeMax = photoSizeMax;
VideoSizeMax = videoSizeMax;
FileSizeMax = fileSizeMax;
VideoUploadMaxbitrate = videoUploadMaxbitrate;
 
}
#nullable disable
        internal AutoDownloadSettings() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Disabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = VideoPreloadLarge ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = AudioPreloadNext ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = PhonecallsLessData ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
		
		public override string ToString()
		{
		    return "autoDownloadSettings";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}