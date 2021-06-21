using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentResultBase : IObject
    {
        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}