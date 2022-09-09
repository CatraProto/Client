using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract partial class DcOptionBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("ipv6")] public abstract bool Ipv6 { get; set; }

        [Newtonsoft.Json.JsonProperty("media_only")]
        public abstract bool MediaOnly { get; set; }

        [Newtonsoft.Json.JsonProperty("tcpo_only")]
        public abstract bool TcpoOnly { get; set; }

        [Newtonsoft.Json.JsonProperty("cdn")] public abstract bool Cdn { get; set; }

        [Newtonsoft.Json.JsonProperty("static")]
        public abstract bool Static { get; set; }

        [Newtonsoft.Json.JsonProperty("this_port_only")]
        public abstract bool ThisPortOnly { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public abstract int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ip_address")]
        public abstract string IpAddress { get; set; }

        [Newtonsoft.Json.JsonProperty("port")] public abstract int Port { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public abstract byte[] Secret { get; set; }

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