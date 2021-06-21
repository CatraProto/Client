using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class PaymentResult : PaymentResultBase
    {
        public static int ConstructorId { get; } = 1314881805;
        public UpdatesBase Updates { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Updates);
        }

        public override void Deserialize(Reader reader)
        {
            Updates = reader.Read<UpdatesBase>();
        }
    }
}