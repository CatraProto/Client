using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMediaPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            TtlSeconds = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => -1279654347;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_seconds")]
        public int? TtlSeconds { get; set; }


    #nullable enable
        public InputMediaPhoto(CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase id)
        {
            Id = id;
        }
    #nullable disable
        internal InputMediaPhoto()
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
            writer.Write(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(TtlSeconds.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                TtlSeconds = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "inputMediaPhoto";
        }
    }
}