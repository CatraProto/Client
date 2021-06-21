using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ShippingOptionBase : IObject
    {
        public abstract string Id { get; set; }
        public abstract string Title { get; set; }
        public abstract IList<LabeledPriceBase> Prices { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}