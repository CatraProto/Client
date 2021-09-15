using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class ExportedAuthorizationBase : IObject
    {
        [JsonProperty("id")] public abstract int Id { get; set; }

        [JsonProperty("bytes")] public abstract byte[] Bytes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}