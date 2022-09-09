using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("part")] public abstract bool Part { get; set; }

        [Newtonsoft.Json.JsonProperty("rtl")] public abstract bool Rtl { get; set; }

        [Newtonsoft.Json.JsonProperty("v2")] public abstract bool V2 { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public abstract string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("blocks")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

        [Newtonsoft.Json.JsonProperty("photos")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

        [Newtonsoft.Json.JsonProperty("documents")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

        [Newtonsoft.Json.JsonProperty("views")]
        public abstract int? Views { get; set; }

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