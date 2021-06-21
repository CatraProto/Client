using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class LabeledPrice : LabeledPriceBase
    {
        public static int ConstructorId { get; } = -886477832;
        public override string Label { get; set; }
        public override long Amount { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Label);
            writer.Write(Amount);
        }

        public override void Deserialize(Reader reader)
        {
            Label = reader.Read<string>();
            Amount = reader.Read<long>();
        }
    }
}