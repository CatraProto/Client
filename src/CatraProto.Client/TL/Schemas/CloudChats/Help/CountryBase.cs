using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats.Help;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class CountryBase : IObject
    {
		public abstract bool Hidden { get; set; }
		public abstract string Iso2 { get; set; }
		public abstract string DefaultName { get; set; }
		public abstract string Name { get; set; }
		public abstract IList<CountryCodeBase> CountryCodes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
