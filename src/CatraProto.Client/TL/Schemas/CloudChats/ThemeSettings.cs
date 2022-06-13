/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ThemeSettings : CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            MessageColorsAnimated = 1 << 2,
            OutboxAccentColor = 1 << 3,
            MessageColors = 1 << 0,
            Wallpaper = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -94849324; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase Wallpaper { get; set; }


#nullable enable
        public ThemeSettings(CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase baseTheme, int accentColor)
        {
            BaseTheme = baseTheme;
            AccentColor = accentColor;

        }
#nullable disable
        internal ThemeSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = MessageColorsAnimated ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = OutboxAccentColor == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = MessageColors == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Wallpaper == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

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
                var trywallpaper = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
                if (trywallpaper.IsError)
                {
                    return ReadResult<IObject>.Move(trywallpaper);
                }
                Wallpaper = trywallpaper.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "themeSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ThemeSettings
            {
                Flags = Flags,
                MessageColorsAnimated = MessageColorsAnimated
            };
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
                var cloneWallpaper = (CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase?)Wallpaper.Clone();
                if (cloneWallpaper is null)
                {
                    return null;
                }
                newClonedObject.Wallpaper = cloneWallpaper;
            }
            return newClonedObject;

        }
#nullable disable
    }
}