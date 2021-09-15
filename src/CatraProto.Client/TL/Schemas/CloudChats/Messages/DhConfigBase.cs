using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class DhConfigBase : IObject
    {
        [JsonProperty("random")] public abstract byte[] Random { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}