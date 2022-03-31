using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageTableCellBase : IObject
    {

[Newtonsoft.Json.JsonProperty("header")]
		public abstract bool Header { get; set; }

[Newtonsoft.Json.JsonProperty("align_center")]
		public abstract bool AlignCenter { get; set; }

[Newtonsoft.Json.JsonProperty("align_right")]
		public abstract bool AlignRight { get; set; }

[Newtonsoft.Json.JsonProperty("valign_middle")]
		public abstract bool ValignMiddle { get; set; }

[Newtonsoft.Json.JsonProperty("valign_bottom")]
		public abstract bool ValignBottom { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[Newtonsoft.Json.JsonProperty("colspan")]
		public abstract int? Colspan { get; set; }

[Newtonsoft.Json.JsonProperty("rowspan")]
		public abstract int? Rowspan { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
