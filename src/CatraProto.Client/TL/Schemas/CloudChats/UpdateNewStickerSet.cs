using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateNewStickerSet : UpdateBase
    {
        public static int ConstructorId { get; } = 1753886890;
        public Messages.StickerSetBase Stickerset { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Stickerset);
        }

        public override void Deserialize(Reader reader)
        {
            Stickerset = reader.Read<Messages.StickerSetBase>();
        }
    }
}