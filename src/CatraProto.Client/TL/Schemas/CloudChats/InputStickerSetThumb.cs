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
    public partial class InputStickerSetThumb : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1652231205; }

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb_version")]
        public int ThumbVersion { get; set; }


#nullable enable
        public InputStickerSetThumb(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, int thumbVersion)
        {
            Stickerset = stickerset;
            ThumbVersion = thumbVersion;
        }
#nullable disable
        internal InputStickerSetThumb()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkstickerset = writer.WriteObject(Stickerset);
            if (checkstickerset.IsError)
            {
                return checkstickerset;
            }

            writer.WriteInt32(ThumbVersion);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (trystickerset.IsError)
            {
                return ReadResult<IObject>.Move(trystickerset);
            }

            Stickerset = trystickerset.Value;
            var trythumbVersion = reader.ReadInt32();
            if (trythumbVersion.IsError)
            {
                return ReadResult<IObject>.Move(trythumbVersion);
            }

            ThumbVersion = trythumbVersion.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputStickerSetThumb";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputStickerSetThumb();
            var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)Stickerset.Clone();
            if (cloneStickerset is null)
            {
                return null;
            }

            newClonedObject.Stickerset = cloneStickerset;
            newClonedObject.ThumbVersion = ThumbVersion;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputStickerSetThumb castedOther)
            {
                return true;
            }

            if (Stickerset.Compare(castedOther.Stickerset))
            {
                return true;
            }

            if (ThumbVersion != castedOther.ThumbVersion)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}