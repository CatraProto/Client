using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ShippingOption : ShippingOptionBase
    {
        public static int ConstructorId { get; } = -1239335713;
        public override string Id { get; set; }
        public override string Title { get; set; }
        public override IList<LabeledPriceBase> Prices { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(Title);
            writer.Write(Prices);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<string>();
            Title = reader.Read<string>();
            Prices = reader.ReadVector<LabeledPriceBase>();
        }
    }
}