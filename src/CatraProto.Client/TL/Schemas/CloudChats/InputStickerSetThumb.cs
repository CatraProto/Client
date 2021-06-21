using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputStickerSetThumb : InputFileLocationBase
    {
        public static int ConstructorId { get; } = 230353641;
        public InputStickerSetBase Stickerset { get; set; }
        public long VolumeId { get; set; }
        public int LocalId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Stickerset);
            writer.Write(VolumeId);
            writer.Write(LocalId);
        }

        public override void Deserialize(Reader reader)
        {
            Stickerset = reader.Read<InputStickerSetBase>();
            VolumeId = reader.Read<long>();
            LocalId = reader.Read<int>();
        }
    }
}