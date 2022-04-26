using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class WallPaperSettings : CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Blur = 1 << 1,
            Motion = 1 << 2,
            BackgroundColor = 1 << 0,
            SecondBackgroundColor = 1 << 4,
            ThirdBackgroundColor = 1 << 5,
            FourthBackgroundColor = 1 << 6,
            Intensity = 1 << 3,
            Rotation = 1 << 4
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 499236004; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("blur")]
        public sealed override bool Blur { get; set; }

        [Newtonsoft.Json.JsonProperty("motion")]
        public sealed override bool Motion { get; set; }

        [Newtonsoft.Json.JsonProperty("background_color")]
        public sealed override int? BackgroundColor { get; set; }

        [Newtonsoft.Json.JsonProperty("second_background_color")]
        public sealed override int? SecondBackgroundColor { get; set; }

        [Newtonsoft.Json.JsonProperty("third_background_color")]
        public sealed override int? ThirdBackgroundColor { get; set; }

        [Newtonsoft.Json.JsonProperty("fourth_background_color")]
        public sealed override int? FourthBackgroundColor { get; set; }

        [Newtonsoft.Json.JsonProperty("intensity")]
        public sealed override int? Intensity { get; set; }

        [Newtonsoft.Json.JsonProperty("rotation")]
        public sealed override int? Rotation { get; set; }



        public WallPaperSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Blur ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Motion ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = BackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = SecondBackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = ThirdBackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = FourthBackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = Intensity == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Rotation == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(BackgroundColor.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(SecondBackgroundColor.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteInt32(ThirdBackgroundColor.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.WriteInt32(FourthBackgroundColor.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt32(Intensity.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(Rotation.Value);
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Blur = FlagsHelper.IsFlagSet(Flags, 1);
            Motion = FlagsHelper.IsFlagSet(Flags, 2);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trybackgroundColor = reader.ReadInt32();
                if (trybackgroundColor.IsError)
                {
                    return ReadResult<IObject>.Move(trybackgroundColor);
                }
                BackgroundColor = trybackgroundColor.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trysecondBackgroundColor = reader.ReadInt32();
                if (trysecondBackgroundColor.IsError)
                {
                    return ReadResult<IObject>.Move(trysecondBackgroundColor);
                }
                SecondBackgroundColor = trysecondBackgroundColor.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var trythirdBackgroundColor = reader.ReadInt32();
                if (trythirdBackgroundColor.IsError)
                {
                    return ReadResult<IObject>.Move(trythirdBackgroundColor);
                }
                ThirdBackgroundColor = trythirdBackgroundColor.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var tryfourthBackgroundColor = reader.ReadInt32();
                if (tryfourthBackgroundColor.IsError)
                {
                    return ReadResult<IObject>.Move(tryfourthBackgroundColor);
                }
                FourthBackgroundColor = tryfourthBackgroundColor.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryintensity = reader.ReadInt32();
                if (tryintensity.IsError)
                {
                    return ReadResult<IObject>.Move(tryintensity);
                }
                Intensity = tryintensity.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryrotation = reader.ReadInt32();
                if (tryrotation.IsError)
                {
                    return ReadResult<IObject>.Move(tryrotation);
                }
                Rotation = tryrotation.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "wallPaperSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WallPaperSettings
            {
                Flags = Flags,
                Blur = Blur,
                Motion = Motion,
                BackgroundColor = BackgroundColor,
                SecondBackgroundColor = SecondBackgroundColor,
                ThirdBackgroundColor = ThirdBackgroundColor,
                FourthBackgroundColor = FourthBackgroundColor,
                Intensity = Intensity,
                Rotation = Rotation
            };
            return newClonedObject;

        }
#nullable disable
    }
}