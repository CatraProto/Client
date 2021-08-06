using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AutoDownloadSettingsBase : IObject
    {

[JsonPropertyName("disabled")]
		public abstract bool Disabled { get; set; }

[JsonPropertyName("video_preload_large")]
		public abstract bool VideoPreloadLarge { get; set; }

[JsonPropertyName("audio_preload_next")]
		public abstract bool AudioPreloadNext { get; set; }

[JsonPropertyName("phonecalls_less_data")]
		public abstract bool PhonecallsLessData { get; set; }

[JsonPropertyName("photo_size_max")]
		public abstract int PhotoSizeMax { get; set; }

[JsonPropertyName("video_size_max")]
		public abstract int VideoSizeMax { get; set; }

[JsonPropertyName("file_size_max")]
		public abstract int FileSizeMax { get; set; }

[JsonPropertyName("video_upload_maxbitrate")]
		public abstract int VideoUploadMaxbitrate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
