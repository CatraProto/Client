using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public abstract class CountryCodeBase : IObject
	{
		public abstract string CountryCode_ { get; set; }
		public abstract IList<string> Prefixes { get; set; }
		public abstract IList<string> Patterns { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}