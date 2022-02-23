using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DocumentAttributeVideo : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            RoundMessage = 1 << 0,
            SupportsStreaming = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => 250621158;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("round_message")]
        public bool RoundMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("supports_streaming")]
        public bool SupportsStreaming { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int Duration { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }


    #nullable enable
        public DocumentAttributeVideo(int duration, int w, int h)
        {
            Duration = duration;
            W = w;
            H = h;
        }
    #nullable disable
        internal DocumentAttributeVideo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = RoundMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = SupportsStreaming ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Duration);
            writer.Write(W);
            writer.Write(H);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            RoundMessage = FlagsHelper.IsFlagSet(Flags, 0);
            SupportsStreaming = FlagsHelper.IsFlagSet(Flags, 1);
            Duration = reader.Read<int>();
            W = reader.Read<int>();
            H = reader.Read<int>();
        }

        public override string ToString()
        {
            return "documentAttributeVideo";
        }
    }
}