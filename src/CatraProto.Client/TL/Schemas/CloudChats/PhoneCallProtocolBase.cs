using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public abstract List<string> LibraryVersions { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}