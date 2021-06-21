using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ShippingOptionBase : IObject
    {
		public abstract string Id { get; set; }
		public abstract string Title { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> Prices { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
