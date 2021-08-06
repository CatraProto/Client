using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageBase : IObject
    {

[JsonPropertyName("part")]
		public abstract bool Part { get; set; }

[JsonPropertyName("rtl")]
		public abstract bool Rtl { get; set; }

[JsonPropertyName("v2")]
		public abstract bool V2 { get; set; }

[JsonPropertyName("url")]
		public abstract string Url { get; set; }

[JsonPropertyName("blocks")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

[JsonPropertyName("photos")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

[JsonPropertyName("documents")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

[JsonPropertyName("views")]
		public abstract int? Views { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
