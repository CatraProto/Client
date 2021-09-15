using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class TmpPasswordBase : IObject
    {
        [JsonProperty("tmp_password")] public abstract byte[] TmpPasswordField { get; set; }

        [JsonProperty("valid_until")] public abstract int ValidUntil { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}