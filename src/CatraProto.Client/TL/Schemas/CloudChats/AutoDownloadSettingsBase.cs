using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AutoDownloadSettingsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("disabled")]
		public abstract bool Disabled { get; set; }

[Newtonsoft.Json.JsonProperty("video_preload_large")]
		public abstract bool VideoPreloadLarge { get; set; }

[Newtonsoft.Json.JsonProperty("audio_preload_next")]
		public abstract bool AudioPreloadNext { get; set; }

[Newtonsoft.Json.JsonProperty("phonecalls_less_data")]
		public abstract bool PhonecallsLessData { get; set; }

[Newtonsoft.Json.JsonProperty("photo_size_max")]
		public abstract int PhotoSizeMax { get; set; }

[Newtonsoft.Json.JsonProperty("video_size_max")]
		public abstract int VideoSizeMax { get; set; }

[Newtonsoft.Json.JsonProperty("file_size_max")]
		public abstract int FileSizeMax { get; set; }

[Newtonsoft.Json.JsonProperty("video_upload_maxbitrate")]
		public abstract int VideoUploadMaxbitrate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
