using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WallPaperBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("id")] public abstract long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("default")]
        public abstract bool Default { get; set; }

        [Newtonsoft.Json.JsonProperty("dark")] public abstract bool Dark { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("settings")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }

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