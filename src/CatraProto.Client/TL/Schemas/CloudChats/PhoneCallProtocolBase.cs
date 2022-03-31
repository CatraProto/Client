using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PhoneCallProtocolBase : IObject
    {

[Newtonsoft.Json.JsonProperty("udp_p2p")]
		public abstract bool UdpP2p { get; set; }

[Newtonsoft.Json.JsonProperty("udp_reflector")]
		public abstract bool UdpReflector { get; set; }

[Newtonsoft.Json.JsonProperty("min_layer")]
		public abstract int MinLayer { get; set; }

[Newtonsoft.Json.JsonProperty("max_layer")]
		public abstract int MaxLayer { get; set; }

[Newtonsoft.Json.JsonProperty("library_versions")]
		public abstract IList<string> LibraryVersions { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
