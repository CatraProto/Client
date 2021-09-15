using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputSecureValueBase : IObject
    {

[Newtonsoft.Json.JsonProperty("type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase Data { get; set; }

[Newtonsoft.Json.JsonProperty("front_side")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase FrontSide { get; set; }

[Newtonsoft.Json.JsonProperty("reverse_side")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase ReverseSide { get; set; }

[Newtonsoft.Json.JsonProperty("selfie")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase Selfie { get; set; }

[Newtonsoft.Json.JsonProperty("translation")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase> Translation { get; set; }

[Newtonsoft.Json.JsonProperty("files")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase> Files { get; set; }

[Newtonsoft.Json.JsonProperty("plain_data")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase PlainData { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
