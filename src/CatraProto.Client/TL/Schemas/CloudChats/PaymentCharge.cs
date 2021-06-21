using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PaymentCharge : PaymentChargeBase
    {
        public static int ConstructorId { get; } = -368917890;
        public override string Id { get; set; }
        public override string ProviderChargeId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(ProviderChargeId);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<string>();
            ProviderChargeId = reader.Read<string>();
        }
    }
}