using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputStickerSetItem : InputStickerSetItemBase
    {
        [Flags]
        public enum FlagsEnum
        {
            MaskCoords = 1 << 0
        }

        public static int ConstructorId { get; } = -6249322;
        public int Flags { get; set; }
        public override InputDocumentBase Document { get; set; }
        public override string Emoji { get; set; }
        public override MaskCoordsBase MaskCoords { get; set; }

        public override void UpdateFlags()
        {
            Flags = MaskCoords == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Document);
            writer.Write(Emoji);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(MaskCoords);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Document = reader.Read<InputDocumentBase>();
            Emoji = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                MaskCoords = reader.Read<MaskCoordsBase>();
            }
        }
    }
}