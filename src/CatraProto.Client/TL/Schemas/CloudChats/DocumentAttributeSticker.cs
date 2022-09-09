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
    public partial class DocumentAttributeSticker : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Mask = 1 << 1,
            MaskCoords = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1662637586; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("mask")] public bool Mask { get; set; }

        [Newtonsoft.Json.JsonProperty("alt")] public string Alt { get; set; }

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("mask_coords")]
        public CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase MaskCoords { get; set; }


#nullable enable
        public DocumentAttributeSticker(string alt, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset)
        {
            Alt = alt;
            Stickerset = stickerset;
        }
#nullable disable
        internal DocumentAttributeSticker()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Mask ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = MaskCoords == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Alt);
            var checkstickerset = writer.WriteObject(Stickerset);
            if (checkstickerset.IsError)
            {
                return checkstickerset;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkmaskCoords = writer.WriteObject(MaskCoords);
                if (checkmaskCoords.IsError)
                {
                    return checkmaskCoords;
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
            Mask = FlagsHelper.IsFlagSet(Flags, 1);
            var tryalt = reader.ReadString();
            if (tryalt.IsError)
            {
                return ReadResult<IObject>.Move(tryalt);
            }

            Alt = tryalt.Value;
            var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (trystickerset.IsError)
            {
                return ReadResult<IObject>.Move(trystickerset);
            }

            Stickerset = trystickerset.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trymaskCoords = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase>();
                if (trymaskCoords.IsError)
                {
                    return ReadResult<IObject>.Move(trymaskCoords);
                }

                MaskCoords = trymaskCoords.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "documentAttributeSticker";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DocumentAttributeSticker();
            newClonedObject.Flags = Flags;
            newClonedObject.Mask = Mask;
            newClonedObject.Alt = Alt;
            var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)Stickerset.Clone();
            if (cloneStickerset is null)
            {
                return null;
            }

            newClonedObject.Stickerset = cloneStickerset;
            if (MaskCoords is not null)
            {
                var cloneMaskCoords = (CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase?)MaskCoords.Clone();
                if (cloneMaskCoords is null)
                {
                    return null;
                }

                newClonedObject.MaskCoords = cloneMaskCoords;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DocumentAttributeSticker castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Mask != castedOther.Mask)
            {
                return true;
            }

            if (Alt != castedOther.Alt)
            {
                return true;
            }

            if (Stickerset.Compare(castedOther.Stickerset))
            {
                return true;
            }

            if (MaskCoords is null && castedOther.MaskCoords is not null || MaskCoords is not null && castedOther.MaskCoords is null)
            {
                return true;
            }

            if (MaskCoords is not null && castedOther.MaskCoords is not null && MaskCoords.Compare(castedOther.MaskCoords))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}