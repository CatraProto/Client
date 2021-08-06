using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class VideoSizeBase : IObject
    {

[JsonPropertyName("type")]
		public abstract string Type { get; set; }

[JsonPropertyName("location")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase Location { get; set; }

[JsonPropertyName("w")]
		public abstract int W { get; set; }

[JsonPropertyName("h")]
		public abstract int H { get; set; }

[JsonPropertyName("size")]
		public abstract int Size { get; set; }

[JsonPropertyName("video_start_ts")]
		public abstract double? VideoStartTs { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
