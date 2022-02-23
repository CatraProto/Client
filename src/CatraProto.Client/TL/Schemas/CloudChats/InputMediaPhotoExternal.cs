using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMediaPhotoExternal : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            TtlSeconds = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => -440664550;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_seconds")]
        public int? TtlSeconds { get; set; }


    #nullable enable
        public InputMediaPhotoExternal(string url)
        {
            Url = url;
        }
    #nullable disable
        internal InputMediaPhotoExternal()
        {
        }

        public override void UpdateFlags()
        {
            Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Url);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(TtlSeconds.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Url = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                TtlSeconds = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "inputMediaPhotoExternal";
        }
    }
}