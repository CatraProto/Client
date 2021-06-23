using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class KeyboardButtonRequestGeoLocation : KeyboardButtonBase
    {
        public static int ConstructorId { get; } = -59151553;
        public override string Text { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Text);
        }

        public override void Deserialize(Reader reader)
        {
            Text = reader.Read<string>();
        }
    }
}