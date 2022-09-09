using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class TopPeerCategoryPeersBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("category")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public abstract int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("peers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase> Peers { get; set; }

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