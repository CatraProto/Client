using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageTableRowBase : IObject
    {

[JsonPropertyName("cells")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> Cells { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
