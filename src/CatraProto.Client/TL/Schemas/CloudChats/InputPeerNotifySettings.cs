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
        public static int ConstructorId { get => -1673717362; }

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
        public sealed override string Sound { get; set; }



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

                writer.WriteString(Sound);
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
                var trysound = reader.ReadString();
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
                MuteUntil = MuteUntil,
                Sound = Sound
            };
            return newClonedObject;

        }
#nullable disable
    }
}