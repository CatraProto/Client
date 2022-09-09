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
    public partial class ChangeStickerPosition : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -4795190; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("sticker")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Sticker { get; set; }

        [Newtonsoft.Json.JsonProperty("position")]
        public int Position { get; set; }


#nullable enable
        public ChangeStickerPosition(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker, int position)
        {
            Sticker = sticker;
            Position = position;
        }
#nullable disable

        internal ChangeStickerPosition()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checksticker = writer.WriteObject(Sticker);
            if (checksticker.IsError)
            {
                return checksticker;
            }

            writer.WriteInt32(Position);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysticker = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (trysticker.IsError)
            {
                return ReadResult<IObject>.Move(trysticker);
            }

            Sticker = trysticker.Value;
            var tryposition = reader.ReadInt32();
            if (tryposition.IsError)
            {
                return ReadResult<IObject>.Move(tryposition);
            }

            Position = tryposition.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stickers.changeStickerPosition";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ChangeStickerPosition();
            var cloneSticker = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Sticker.Clone();
            if (cloneSticker is null)
            {
                return null;
            }

            newClonedObject.Sticker = cloneSticker;
            newClonedObject.Position = Position;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ChangeStickerPosition castedOther)
            {
                return true;
            }

            if (Sticker.Compare(castedOther.Sticker))
            {
                return true;
            }

            if (Position != castedOther.Position)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}