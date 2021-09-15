using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FileLocationBase : IObject
    {

[Newtonsoft.Json.JsonProperty("volume_id")]
		public abstract long VolumeId { get; set; }

[Newtonsoft.Json.JsonProperty("local_id")]
		public abstract int LocalId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
