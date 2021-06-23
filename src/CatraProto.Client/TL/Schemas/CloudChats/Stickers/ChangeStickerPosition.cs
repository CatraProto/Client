using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public class ChangeStickerPosition : IMethod
    {
        public static int ConstructorId { get; } = -4795190;

        public System.Type Type { get; init; } = typeof(Messages.StickerSetBase);
        public bool IsVector { get; init; } = false;
        public InputDocumentBase Sticker { get; set; }
        public int Position { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Sticker);
            writer.Write(Position);
        }

        public void Deserialize(Reader reader)
        {
            Sticker = reader.Read<InputDocumentBase>();
            Position = reader.Read<int>();
        }
    }
}