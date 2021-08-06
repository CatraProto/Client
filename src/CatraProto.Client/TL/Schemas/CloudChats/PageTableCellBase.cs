using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageTableCellBase : IObject
    {

[JsonPropertyName("header")]
		public abstract bool Header { get; set; }

[JsonPropertyName("align_center")]
		public abstract bool AlignCenter { get; set; }

[JsonPropertyName("align_right")]
		public abstract bool AlignRight { get; set; }

[JsonPropertyName("valign_middle")]
		public abstract bool ValignMiddle { get; set; }

[JsonPropertyName("valign_bottom")]
		public abstract bool ValignBottom { get; set; }

[JsonPropertyName("text")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[JsonPropertyName("colspan")]
		public abstract int? Colspan { get; set; }

[JsonPropertyName("rowspan")]
		public abstract int? Rowspan { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
