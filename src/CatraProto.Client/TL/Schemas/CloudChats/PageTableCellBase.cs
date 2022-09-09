using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("text")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("colspan")]
        public abstract int? Colspan { get; set; }

        [Newtonsoft.Json.JsonProperty("rowspan")]
        public abstract int? Rowspan { get; set; }

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