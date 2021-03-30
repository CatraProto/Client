using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PhoneCallProtocolBase : IObject
    {
		public abstract bool UdpP2p { get; set; }
		public abstract bool UdpReflector { get; set; }
		public abstract int MinLayer { get; set; }
		public abstract int MaxLayer { get; set; }
		public abstract IList<string> LibraryVersions { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
