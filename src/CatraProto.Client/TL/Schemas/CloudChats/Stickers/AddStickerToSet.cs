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
    public partial class AddStickerToSet : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2041315650; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("sticker")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase Sticker { get; set; }


#nullable enable
        public AddStickerToSet(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase sticker)
        {
            Stickerset = stickerset;
            Sticker = sticker;
        }
#nullable disable

        internal AddStickerToSet()
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

            var checksticker = writer.WriteObject(Sticker);
            if (checksticker.IsError)
            {
                return checksticker;
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
            var trysticker = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase>();
            if (trysticker.IsError)
            {
                return ReadResult<IObject>.Move(trysticker);
            }

            Sticker = trysticker.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stickers.addStickerToSet";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AddStickerToSet();
            var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)Stickerset.Clone();
            if (cloneStickerset is null)
            {
                return null;
            }

            newClonedObject.Stickerset = cloneStickerset;
            var cloneSticker = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase?)Sticker.Clone();
            if (cloneSticker is null)
            {
                return null;
            }

            newClonedObject.Sticker = cloneSticker;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not AddStickerToSet castedOther)
            {
                return true;
            }

            if (Stickerset.Compare(castedOther.Stickerset))
            {
                return true;
            }

            if (Sticker.Compare(castedOther.Sticker))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}