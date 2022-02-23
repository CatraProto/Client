using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class LabeledPrice : CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase
    {
        public static int StaticConstructorId
        {
            get => -886477832;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("label")]
        public sealed override string Label { get; set; }

        [Newtonsoft.Json.JsonProperty("amount")]
        public sealed override long Amount { get; set; }


    #nullable enable
        public LabeledPrice(string label, long amount)
        {
            Label = label;
            Amount = amount;
        }
    #nullable disable
        internal LabeledPrice()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Label);
            writer.Write(Amount);
        }

        public override void Deserialize(Reader reader)
        {
            Label = reader.Read<string>();
            Amount = reader.Read<long>();
        }

        public override string ToString()
        {
            return "labeledPrice";
        }
    }
}