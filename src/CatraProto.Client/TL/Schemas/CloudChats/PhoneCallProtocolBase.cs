using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PhoneCallProtocolBase : IObject
    {

[JsonPropertyName("udp_p2p")]
		public abstract bool UdpP2p { get; set; }

[JsonPropertyName("udp_reflector")]
		public abstract bool UdpReflector { get; set; }

[JsonPropertyName("min_layer")]
		public abstract int MinLayer { get; set; }

[JsonPropertyName("max_layer")]
		public abstract int MaxLayer { get; set; }

[JsonPropertyName("library_versions")]
		public abstract IList<string> LibraryVersions { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
