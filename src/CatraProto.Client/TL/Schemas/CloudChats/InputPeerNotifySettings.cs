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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPeerNotifySettings : CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ShowPreviews = 1 << 0,
            Silent = 1 << 1,
            MuteUntil = 1 << 2,
            Sound = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -551616469; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("show_previews")]
        public sealed override bool? ShowPreviews { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public sealed override bool? Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("mute_until")]
        public sealed override int? MuteUntil { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("sound")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase Sound { get; set; }



        public InputPeerNotifySettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ShowPreviews == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Silent == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = MuteUntil == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Sound == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkshowPreviews = writer.WriteBool(ShowPreviews.Value);
                if (checkshowPreviews.IsError)
                {
                    return checkshowPreviews;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checksilent = writer.WriteBool(Silent.Value);
                if (checksilent.IsError)
                {
                    return checksilent;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(MuteUntil.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checksound = writer.WriteObject(Sound);
                if (checksound.IsError)
                {
                    return checksound;
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryshowPreviews = reader.ReadBool();
                if (tryshowPreviews.IsError)
                {
                    return ReadResult<IObject>.Move(tryshowPreviews);
                }
                ShowPreviews = tryshowPreviews.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trysilent = reader.ReadBool();
                if (trysilent.IsError)
                {
                    return ReadResult<IObject>.Move(trysilent);
                }
                Silent = trysilent.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trymuteUntil = reader.ReadInt32();
                if (trymuteUntil.IsError)
                {
                    return ReadResult<IObject>.Move(trymuteUntil);
                }
                MuteUntil = trymuteUntil.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trysound = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase>();
                if (trysound.IsError)
                {
                    return ReadResult<IObject>.Move(trysound);
                }
                Sound = trysound.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputPeerNotifySettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPeerNotifySettings
            {
                Flags = Flags,
                ShowPreviews = ShowPreviews,
                Silent = Silent,
                MuteUntil = MuteUntil
            };
            if (Sound is not null)
            {
                var cloneSound = (CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase?)Sound.Clone();
                if (cloneSound is null)
                {
                    return null;
                }
                newClonedObject.Sound = cloneSound;
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPeerNotifySettings castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (ShowPreviews != castedOther.ShowPreviews)
            {
                return true;
            }
            if (Silent != castedOther.Silent)
            {
                return true;
            }
            if (MuteUntil != castedOther.MuteUntil)
            {
                return true;
            }
            if (Sound is null && castedOther.Sound is not null || Sound is not null && castedOther.Sound is null)
            {
                return true;
            }
            if (Sound is not null && castedOther.Sound is not null && Sound.Compare(castedOther.Sound))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}