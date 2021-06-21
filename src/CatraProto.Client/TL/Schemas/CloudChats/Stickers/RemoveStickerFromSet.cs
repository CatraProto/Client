using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class RemoveStickerFromSet : IMethod
    {
        public static int ConstructorId { get; } = -143257775;
        public InputDocumentBase Sticker { get; set; }

        public Type Type { get; init; } = typeof(Messages.StickerSetBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Sticker);
        }

        public void Deserialize(Reader reader)
        {
            Sticker = reader.Read<InputDocumentBase>();
        }
    }
}