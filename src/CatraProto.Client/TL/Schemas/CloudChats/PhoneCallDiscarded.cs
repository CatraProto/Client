using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PhoneCallDiscarded : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NeedRating = 1 << 2,
            NeedDebug = 1 << 3,
            Video = 1 << 6,
            Reason = 1 << 0,
            Duration = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => 1355435489;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("need_rating")]
        public bool NeedRating { get; set; }

        [Newtonsoft.Json.JsonProperty("need_debug")]
        public bool NeedDebug { get; set; }

        [Newtonsoft.Json.JsonProperty("video")]
        public bool Video { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("reason")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }


    #nullable enable
        public PhoneCallDiscarded(long id)
        {
            Id = id;
        }
    #nullable disable
        internal PhoneCallDiscarded()
        {
        }

        public override void UpdateFlags()
        {
            Flags = NeedRating ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = NeedDebug ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = Reason == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Duration == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Reason);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Duration.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            NeedRating = FlagsHelper.IsFlagSet(Flags, 2);
            NeedDebug = FlagsHelper.IsFlagSet(Flags, 3);
            Video = FlagsHelper.IsFlagSet(Flags, 6);
            Id = reader.Read<long>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Reason = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Duration = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "phoneCallDiscarded";
        }
    }
}