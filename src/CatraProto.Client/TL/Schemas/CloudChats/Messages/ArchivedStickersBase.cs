using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class ArchivedStickersBase : IObject
    {
        [JsonProperty("count")] public abstract int Count { get; set; }

        [JsonProperty("sets")] public abstract IList<StickerSetCoveredBase> Sets { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}