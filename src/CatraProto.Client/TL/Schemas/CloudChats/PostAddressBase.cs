using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PostAddressBase : IObject
    {
		public abstract string StreetLine1 { get; set; }
		public abstract string StreetLine2 { get; set; }
		public abstract string City { get; set; }
		public abstract string State { get; set; }
		public abstract string CountryIso2 { get; set; }
		public abstract string PostCode { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
