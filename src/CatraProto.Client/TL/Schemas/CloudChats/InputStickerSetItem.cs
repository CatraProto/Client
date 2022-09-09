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
    public partial class InputStickerSetItem : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase
    {
        [Flags]
        public enum FlagsEnum
        {
            MaskCoords = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -6249322; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("document")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

        [Newtonsoft.Json.JsonProperty("emoji")]
        public sealed override string Emoji { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("mask_coords")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase MaskCoords { get; set; }


#nullable enable
        public InputStickerSetItem(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase document, string emoji)
        {
            Document = document;
            Emoji = emoji;
        }
#nullable disable
        internal InputStickerSetItem()
        {
        }

        public override void UpdateFlags()
        {
            Flags = MaskCoords == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkdocument = writer.WriteObject(Document);
            if (checkdocument.IsError)
            {
                return checkdocument;
            }

            writer.WriteString(Emoji);
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
            var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (trydocument.IsError)
            {
                return ReadResult<IObject>.Move(trydocument);
            }

            Document = trydocument.Value;
            var tryemoji = reader.ReadString();
            if (tryemoji.IsError)
            {
                return ReadResult<IObject>.Move(tryemoji);
            }

            Emoji = tryemoji.Value;
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
            return "inputStickerSetItem";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputStickerSetItem();
            newClonedObject.Flags = Flags;
            var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Document.Clone();
            if (cloneDocument is null)
            {
                return null;
            }

            newClonedObject.Document = cloneDocument;
            newClonedObject.Emoji = Emoji;
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
            if (other is not InputStickerSetItem castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Document.Compare(castedOther.Document))
            {
                return true;
            }

            if (Emoji != castedOther.Emoji)
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