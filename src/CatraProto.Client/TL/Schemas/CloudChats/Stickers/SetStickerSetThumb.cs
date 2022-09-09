using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class SetStickerSetThumb : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1707717072; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Thumb { get; set; }


#nullable enable
        public SetStickerSetThumb(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase thumb)
        {
            Stickerset = stickerset;
            Thumb = thumb;
        }
#nullable disable

        internal SetStickerSetThumb()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkstickerset = writer.WriteObject(Stickerset);
            if (checkstickerset.IsError)
            {
                return checkstickerset;
            }

            var checkthumb = writer.WriteObject(Thumb);
            if (checkthumb.IsError)
            {
                return checkthumb;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (trystickerset.IsError)
            {
                return ReadResult<IObject>.Move(trystickerset);
            }

            Stickerset = trystickerset.Value;
            var trythumb = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (trythumb.IsError)
            {
                return ReadResult<IObject>.Move(trythumb);
            }

            Thumb = trythumb.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stickers.setStickerSetThumb";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetStickerSetThumb();
            var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)Stickerset.Clone();
            if (cloneStickerset is null)
            {
                return null;
            }

            newClonedObject.Stickerset = cloneStickerset;
            var cloneThumb = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Thumb.Clone();
            if (cloneThumb is null)
            {
                return null;
            }

            newClonedObject.Thumb = cloneThumb;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetStickerSetThumb castedOther)
            {
                return true;
            }

            if (Stickerset.Compare(castedOther.Stickerset))
            {
                return true;
            }

            if (Thumb.Compare(castedOther.Thumb))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}