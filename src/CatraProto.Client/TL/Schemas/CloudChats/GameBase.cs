using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GameBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("id")] public abstract long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public abstract long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public abstract string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public abstract string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("document")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

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