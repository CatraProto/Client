using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class GetStickerSet : IMethod
    {
        public static int ConstructorId { get; } = 639215886;

        public System.Type Type { get; init; } = typeof(StickerSetBase);
        public bool IsVector { get; init; } = false;
        public InputStickerSetBase Stickerset { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Stickerset);
        }

        public void Deserialize(Reader reader)
        {
            Stickerset = reader.Read<InputStickerSetBase>();
        }
    }
}