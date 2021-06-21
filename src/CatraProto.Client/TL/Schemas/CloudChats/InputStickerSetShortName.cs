using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputStickerSetShortName : InputStickerSetBase
    {
        public static int ConstructorId { get; } = -2044933984;
        public string ShortName { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ShortName);
        }

        public override void Deserialize(Reader reader)
        {
            ShortName = reader.Read<string>();
        }
    }
}