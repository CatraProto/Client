using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class WallPaperSettings : WallPaperSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Blur = 1 << 1,
            Motion = 1 << 2,
            BackgroundColor = 1 << 0,
            SecondBackgroundColor = 1 << 4,
            Intensity = 1 << 3,
            Rotation = 1 << 4
        }

        public static int ConstructorId { get; } = 84438264;
        public int Flags { get; set; }
        public override bool Blur { get; set; }
        public override bool Motion { get; set; }
        public override int? BackgroundColor { get; set; }
        public override int? SecondBackgroundColor { get; set; }
        public override int? Intensity { get; set; }
        public override int? Rotation { get; set; }

        public override void UpdateFlags()
        {
            Flags = Blur ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Motion ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = BackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = SecondBackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = Intensity == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Rotation == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(BackgroundColor.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(SecondBackgroundColor.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Intensity.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(Rotation.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Blur = FlagsHelper.IsFlagSet(Flags, 1);
            Motion = FlagsHelper.IsFlagSet(Flags, 2);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                BackgroundColor = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                SecondBackgroundColor = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Intensity = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                Rotation = reader.Read<int>();
            }
        }
    }
}