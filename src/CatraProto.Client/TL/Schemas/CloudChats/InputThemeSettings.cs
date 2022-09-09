using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputThemeSettings : CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            MessageColorsAnimated = 1 << 2,
            OutboxAccentColor = 1 << 3,
            MessageColors = 1 << 0,
            Wallpaper = 1 << 1,
            WallpaperSettings = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1881255857; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("message_colors_animated")]
        public sealed override bool MessageColorsAnimated { get; set; }

        [Newtonsoft.Json.JsonProperty("base_theme")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase BaseTheme { get; set; }

        [Newtonsoft.Json.JsonProperty("accent_color")]
        public sealed override int AccentColor { get; set; }

        [Newtonsoft.Json.JsonProperty("outbox_accent_color")]
        public sealed override int? OutboxAccentColor { get; set; }

        [Newtonsoft.Json.JsonProperty("message_colors")]
        public sealed override List<int> MessageColors { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("wallpaper")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase Wallpaper { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("wallpaper_settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase WallpaperSettings { get; set; }


#nullable enable
        public InputThemeSettings(CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase baseTheme, int accentColor)
        {
            BaseTheme = baseTheme;
            AccentColor = accentColor;
        }
#nullable disable
        internal InputThemeSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = MessageColorsAnimated ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = OutboxAccentColor == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = MessageColors == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Wallpaper == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = WallpaperSettings == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkbaseTheme = writer.WriteObject(BaseTheme);
            if (checkbaseTheme.IsError)
            {
                return checkbaseTheme;
            }

            writer.WriteInt32(AccentColor);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt32(OutboxAccentColor.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteVector(MessageColors, false);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkwallpaper = writer.WriteObject(Wallpaper);
                if (checkwallpaper.IsError)
                {
                    return checkwallpaper;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkwallpaperSettings = writer.WriteObject(WallpaperSettings);
                if (checkwallpaperSettings.IsError)
                {
                    return checkwallpaperSettings;
                }
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
            MessageColorsAnimated = FlagsHelper.IsFlagSet(Flags, 2);
            var trybaseTheme = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase>();
            if (trybaseTheme.IsError)
            {
                return ReadResult<IObject>.Move(trybaseTheme);
            }

            BaseTheme = trybaseTheme.Value;
            var tryaccentColor = reader.ReadInt32();
            if (tryaccentColor.IsError)
            {
                return ReadResult<IObject>.Move(tryaccentColor);
            }

            AccentColor = tryaccentColor.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryoutboxAccentColor = reader.ReadInt32();
                if (tryoutboxAccentColor.IsError)
                {
                    return ReadResult<IObject>.Move(tryoutboxAccentColor);
                }

                OutboxAccentColor = tryoutboxAccentColor.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trymessageColors = reader.ReadVector<int>(ParserTypes.Int);
                if (trymessageColors.IsError)
                {
                    return ReadResult<IObject>.Move(trymessageColors);
                }

                MessageColors = trymessageColors.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trywallpaper = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>();
                if (trywallpaper.IsError)
                {
                    return ReadResult<IObject>.Move(trywallpaper);
                }

                Wallpaper = trywallpaper.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trywallpaperSettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();
                if (trywallpaperSettings.IsError)
                {
                    return ReadResult<IObject>.Move(trywallpaperSettings);
                }

                WallpaperSettings = trywallpaperSettings.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputThemeSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputThemeSettings();
            newClonedObject.Flags = Flags;
            newClonedObject.MessageColorsAnimated = MessageColorsAnimated;
            var cloneBaseTheme = (CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase?)BaseTheme.Clone();
            if (cloneBaseTheme is null)
            {
                return null;
            }

            newClonedObject.BaseTheme = cloneBaseTheme;
            newClonedObject.AccentColor = AccentColor;
            newClonedObject.OutboxAccentColor = OutboxAccentColor;
            if (MessageColors is not null)
            {
                newClonedObject.MessageColors = new List<int>();
                foreach (var messageColors in MessageColors)
                {
                    newClonedObject.MessageColors.Add(messageColors);
                }
            }

            if (Wallpaper is not null)
            {
                var cloneWallpaper = (CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase?)Wallpaper.Clone();
                if (cloneWallpaper is null)
                {
                    return null;
                }

                newClonedObject.Wallpaper = cloneWallpaper;
            }

            if (WallpaperSettings is not null)
            {
                var cloneWallpaperSettings = (CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase?)WallpaperSettings.Clone();
                if (cloneWallpaperSettings is null)
                {
                    return null;
                }

                newClonedObject.WallpaperSettings = cloneWallpaperSettings;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputThemeSettings castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (MessageColorsAnimated != castedOther.MessageColorsAnimated)
            {
                return true;
            }

            if (BaseTheme.Compare(castedOther.BaseTheme))
            {
                return true;
            }

            if (AccentColor != castedOther.AccentColor)
            {
                return true;
            }

            if (OutboxAccentColor != castedOther.OutboxAccentColor)
            {
                return true;
            }

            if (MessageColors is null && castedOther.MessageColors is not null || MessageColors is not null && castedOther.MessageColors is null)
            {
                return true;
            }

            if (MessageColors is not null && castedOther.MessageColors is not null)
            {
                var messageColorssize = castedOther.MessageColors.Count;
                if (messageColorssize != MessageColors.Count)
                {
                    return true;
                }

                for (var i = 0; i < messageColorssize; i++)
                {
                    if (castedOther.MessageColors[i] != MessageColors[i])
                    {
                        return true;
                    }
                }
            }

            if (Wallpaper is null && castedOther.Wallpaper is not null || Wallpaper is not null && castedOther.Wallpaper is null)
            {
                return true;
            }

            if (Wallpaper is not null && castedOther.Wallpaper is not null && Wallpaper.Compare(castedOther.Wallpaper))
            {
                return true;
            }

            if (WallpaperSettings is null && castedOther.WallpaperSettings is not null || WallpaperSettings is not null && castedOther.WallpaperSettings is null)
            {
                return true;
            }

            if (WallpaperSettings is not null && castedOther.WallpaperSettings is not null && WallpaperSettings.Compare(castedOther.WallpaperSettings))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}