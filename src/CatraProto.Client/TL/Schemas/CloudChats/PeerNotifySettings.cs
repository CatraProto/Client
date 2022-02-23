using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerNotifySettings : CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ShowPreviews = 1 << 0,
            Silent = 1 << 1,
            MuteUntil = 1 << 2,
            Sound = 1 << 3
        }

        public static int StaticConstructorId
        {
            get => -1353671392;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("show_previews")]
        public sealed override bool? ShowPreviews { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public sealed override bool? Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("mute_until")]
        public sealed override int? MuteUntil { get; set; }

        [Newtonsoft.Json.JsonProperty("sound")]
        public sealed override string Sound { get; set; }


        public PeerNotifySettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ShowPreviews == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Silent == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = MuteUntil == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Sound == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(ShowPreviews.Value);
            writer.Write(Silent.Value);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(MuteUntil.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Sound);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                ShowPreviews = reader.Read<bool>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Silent = reader.Read<bool>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                MuteUntil = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Sound = reader.Read<string>();
            }
        }

        public override string ToString()
        {
            return "peerNotifySettings";
        }
    }
}