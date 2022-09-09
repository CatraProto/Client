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
    public partial class PeerNotifySettings : CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ShowPreviews = 1 << 0,
            Silent = 1 << 1,
            MuteUntil = 1 << 2,
            IosSound = 1 << 3,
            AndroidSound = 1 << 4,
            OtherSound = 1 << 5
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1472527322; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("show_previews")]
        public sealed override bool? ShowPreviews { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public sealed override bool? Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("mute_until")]
        public sealed override int? MuteUntil { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("ios_sound")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase IosSound { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("android_sound")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase AndroidSound { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("other_sound")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase OtherSound { get; set; }


        public PeerNotifySettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ShowPreviews == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Silent == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = MuteUntil == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = IosSound == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = AndroidSound == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = OtherSound == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
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
                var checkiosSound = writer.WriteObject(IosSound);
                if (checkiosSound.IsError)
                {
                    return checkiosSound;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checkandroidSound = writer.WriteObject(AndroidSound);
                if (checkandroidSound.IsError)
                {
                    return checkandroidSound;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var checkotherSound = writer.WriteObject(OtherSound);
                if (checkotherSound.IsError)
                {
                    return checkotherSound;
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
                var tryiosSound = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase>();
                if (tryiosSound.IsError)
                {
                    return ReadResult<IObject>.Move(tryiosSound);
                }

                IosSound = tryiosSound.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryandroidSound = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase>();
                if (tryandroidSound.IsError)
                {
                    return ReadResult<IObject>.Move(tryandroidSound);
                }

                AndroidSound = tryandroidSound.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryotherSound = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase>();
                if (tryotherSound.IsError)
                {
                    return ReadResult<IObject>.Move(tryotherSound);
                }

                OtherSound = tryotherSound.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "peerNotifySettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerNotifySettings();
            newClonedObject.Flags = Flags;
            newClonedObject.ShowPreviews = ShowPreviews;
            newClonedObject.Silent = Silent;
            newClonedObject.MuteUntil = MuteUntil;
            if (IosSound is not null)
            {
                var cloneIosSound = (CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase?)IosSound.Clone();
                if (cloneIosSound is null)
                {
                    return null;
                }

                newClonedObject.IosSound = cloneIosSound;
            }

            if (AndroidSound is not null)
            {
                var cloneAndroidSound = (CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase?)AndroidSound.Clone();
                if (cloneAndroidSound is null)
                {
                    return null;
                }

                newClonedObject.AndroidSound = cloneAndroidSound;
            }

            if (OtherSound is not null)
            {
                var cloneOtherSound = (CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase?)OtherSound.Clone();
                if (cloneOtherSound is null)
                {
                    return null;
                }

                newClonedObject.OtherSound = cloneOtherSound;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerNotifySettings castedOther)
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

            if (IosSound is null && castedOther.IosSound is not null || IosSound is not null && castedOther.IosSound is null)
            {
                return true;
            }

            if (IosSound is not null && castedOther.IosSound is not null && IosSound.Compare(castedOther.IosSound))
            {
                return true;
            }

            if (AndroidSound is null && castedOther.AndroidSound is not null || AndroidSound is not null && castedOther.AndroidSound is null)
            {
                return true;
            }

            if (AndroidSound is not null && castedOther.AndroidSound is not null && AndroidSound.Compare(castedOther.AndroidSound))
            {
                return true;
            }

            if (OtherSound is null && castedOther.OtherSound is not null || OtherSound is not null && castedOther.OtherSound is null)
            {
                return true;
            }

            if (OtherSound is not null && castedOther.OtherSound is not null && OtherSound.Compare(castedOther.OtherSound))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}