using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class VideoSizeBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("type")]
        public abstract string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("w")]
        public abstract int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")]
        public abstract int H { get; set; }

        [Newtonsoft.Json.JsonProperty("size")]
        public abstract int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("video_start_ts")]
        public abstract double? VideoStartTs { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
